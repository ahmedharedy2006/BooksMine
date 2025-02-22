﻿using BooksMine.DataAccess.Repository.interfaces;
using BooksMine.Models.ViewModels;
using BooksMine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;
using BooksMine.Models.Models;
using BooksMine.Utility;
using Stripe.Checkout;

namespace BooksMineWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartViewModel cart = new()
            {
                ListCart = _unitOfWork.shoppingCartRepo.GetAllAsync(
                    s => s.AppUserId == userId,
                    new Expression<Func<ShoppingCart, object>>[] { s => s.book }
                    ).Result.ToList(),

                OrderHeader = new()
            };

            foreach (var item in cart.ListCart)
            {
                cart.OrderHeader.orderTotal += (item.Count * item.book.price);
            }

            return View(cart);
        }

        public async Task<IActionResult> summary()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartViewModel cart = new()
            {
                ListCart = _unitOfWork.shoppingCartRepo.GetAllAsync(
                    s => s.AppUserId == userId,
                    new Expression<Func<ShoppingCart, object>>[] { s => s.book }
                    ).Result.ToList(),

                OrderHeader = new()
            };

            cart.OrderHeader.AppUser = await _unitOfWork.appUserRepo.GetAsync(u => u.Id == userId);

            cart.OrderHeader.Name = cart.OrderHeader.AppUser.FirstName + cart.OrderHeader.AppUser.LastName;

            cart.OrderHeader.phoneNumber = cart.OrderHeader.AppUser.PhoneNumber;

            cart.OrderHeader.state = cart.OrderHeader.AppUser.state;

            cart.OrderHeader.city = cart.OrderHeader.AppUser.city;

            cart.OrderHeader.streetAddress = cart.OrderHeader.AppUser.streetAddress;

            cart.OrderHeader.postalCode = cart.OrderHeader.AppUser.postalCode;

            foreach (var item in cart.ListCart)
            {
                cart.OrderHeader.orderTotal += (item.Count * item.book.price);
            }

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> summary(ShoppingCartViewModel cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            cart.OrderHeader.ShippingDate = System.DateTime.Now;
            cart.OrderHeader.AppUserId = userId;
            cart.OrderHeader.orderStatus = SD.StatusPending;
            cart.OrderHeader.paymentStatus = SD.PaymentStatusPending;
            cart.ListCart = _unitOfWork.shoppingCartRepo.GetAllAsync(
                    s => s.AppUserId == userId,
                    new Expression<Func<ShoppingCart, object>>[] { s => s.book }
                    ).Result.ToList();
            foreach (var item in cart.ListCart)
            {
                cart.OrderHeader.orderTotal += (item.Count * item.book.price);
            }

            await _unitOfWork.orderHeaderRepo.CreateAsync(cart.OrderHeader);
            await _unitOfWork.saveAsync();

            foreach (var item in cart.ListCart)
            {
                OrderDetails orderDetails = new()
                {
                    bookId = item.book.Id,
                    orderHeaderId = cart.OrderHeader.Id,
                    count = item.Count,
                    price = item.book.price
                };

                await _unitOfWork.orderDetailsRepo.CreateAsync(orderDetails);
                await _unitOfWork.saveAsync();

                var options = new Stripe.Checkout.SessionCreateOptions
                {
                    SuccessUrl = "https://localhost:7132/",
                    CancelUrl = "https://localhost:7132/privacy",
                    LineItems = new List<Stripe.Checkout.SessionLineItemOptions>(),
                    Mode = "payment",
                };

                foreach (var cartItem in cart.ListCart)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)cartItem.book.price * 100,
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = cartItem.book.title,
                            }
                        },
                        Quantity = cartItem.Count
                    };
                    options.LineItems.Add(sessionLineItem);
                }

                var service = new SessionService();
                Session session = service.Create(options);
                _unitOfWork.orderHeaderRepo.UpdateStripePaymentIntentId(cart.OrderHeader.Id, session.PaymentIntentId, session.Id);
                _unitOfWork.saveAsync();
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);

            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> OrderConfirm(int id)
        {
            OrderHeader orderHeader = await _unitOfWork.orderHeaderRepo.GetAsync(o => o.Id == id);

            var service = new SessionService();
            Session session = service.Get(orderHeader.sessionId);

            if (session.PaymentStatus.ToLower() == "paid")
            {
                _unitOfWork.orderHeaderRepo.UpdateStripePaymentIntentId(id, session.Id, session.PaymentIntentId);
                _unitOfWork.orderHeaderRepo.UpdateStatus(orderHeader.Id, SD.StatusApproved, SD.PaymentStatusApproved);
                _unitOfWork.saveAsync();
            }

            List<ShoppingCart> shoppingCart = _unitOfWork.shoppingCartRepo.GetAllAsync(s => s.AppUserId == orderHeader.AppUserId).Result.ToList();
            await _unitOfWork.shoppingCartRepo.RemoveRangeAsync(shoppingCart);
            await _unitOfWork.saveAsync();

            return View();
        }
    }
}
    
