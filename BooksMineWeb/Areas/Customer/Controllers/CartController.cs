using BooksMine.DataAccess.Repository.interfaces;
using BooksMine.Models.ViewModels;
using BooksMine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;
using BooksMine.Models.Models;

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

            foreach(var item in cart.ListCart)
            {
                cart.OrderHeader.orderTotal += (item.Count * item.book.price);
            }
            
            return View(cart);
        }

        public async Task<IActionResult> summary(ShoppingCartViewModel cart)
        {
            cart.OrderHeader.AppUser = await _unitOfWork.appUserRepo.GetAsync(u => u.Id == cart.OrderHeader.AppUserId);

            cart.OrderHeader.Name = cart.OrderHeader.AppUser.FirstName + cart.OrderHeader.AppUser.LastName;

            cart.OrderHeader.phoneNumber = cart.OrderHeader.AppUser.PhoneNumber;

            cart.OrderHeader.state = cart.OrderHeader.AppUser.state;

            cart.OrderHeader.city = cart.OrderHeader.AppUser.city;

            cart.OrderHeader.streetAddress = cart.OrderHeader.AppUser.streetAddress;

            cart.OrderHeader.postalCode = cart.OrderHeader.AppUser.postalCode;

            return View(cart);
        }
    }
}
