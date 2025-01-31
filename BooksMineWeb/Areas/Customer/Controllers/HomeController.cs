using BooksMine.DataAccess.Repository.interfaces;
using BooksMine.Models;
using BooksMine.Models.Models;
using BooksMine.Models.ViewModels;
using BooksMineWeb.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BooksMineWeb.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger , AppDbContext db , IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Books()
        {
            var books = await _unitOfWork.bookRepo.GetAllAsync(
                null,
               new Expression<Func<Book, object>>[] { b => b.publisher ,
               b => b.author,
               b => b.category
               }
                );

            var booksView = books.Select(book => new BooksViewModel
            {
                Id = book.Id,
                Title = book.title,
                Description = book.description,
                AuthorName = book.author.firstName + book.author.lastName,
                PublisherName = book.publisher.name,
                Price = book.price,
                CategoryName = book.category.name,
                NoInStock = book.noInStock,
                imgUrl = book.imgUrl

            }).ToList();

            return View(booksView);
        }

        public async Task<IActionResult> BookDetails(int id)
        {
            var book = await _unitOfWork.bookRepo.GetAsync(
                b => b.Id == id,
                false,
                new Expression<Func<Book, object>>[] { b => b.publisher,
                b => b.author,
                b => b.category
                }
                );

            BooksViewModel bookView = new ()
            {
                Id = book.Id,
                Title = book.title,
                Description = book.description,
                AuthorName = book.author.firstName + book.author.lastName,
                PublisherName = book.publisher.name,
                Price = book.price,
                CategoryName = book.category.name,
                NoInStock = book.noInStock,
                imgUrl = book.imgUrl

            };

            ShoppingCart cart = new()
            {
                booksViewModel = bookView,
                bookId = book.Id,
                Count = 1
            };
            

            return View(cart);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
