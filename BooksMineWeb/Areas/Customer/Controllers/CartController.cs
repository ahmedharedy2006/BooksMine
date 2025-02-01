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
                    ).Result.ToList()
            };

            foreach(var item in cart.ListCart)
            {
                cart.totalOrder += (item.Count * item.book.price);
            }
            
            return View(cart);
        }
    }
}
