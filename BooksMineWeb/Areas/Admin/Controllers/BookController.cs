using BooksMine.DataAccess.Repository.interfaces;
using BooksMine.Models;
using BooksMine.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Xml;

namespace BooksMineWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IUnitOfWork unitOfWork , IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
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

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        

        public async Task<IActionResult> Upsert(int? id)
        {
         var categories = await _unitOfWork.categoryRepo
                .GetAllAsync();

        var authors = await _unitOfWork.authorRepo
                  .GetAllAsync();

            var publishers = await _unitOfWork.publisherRepo
                 .GetAllAsync();

            IEnumerable<SelectListItem> CategoryList = categories
               .Select(u => new SelectListItem
            {
                Text = u.name,
                Value = u.Id.ToString()
            });

            IEnumerable<SelectListItem> publisherList = publishers
          .Select(u => new SelectListItem
          {
              Text = u.name,
              Value = u.Id.ToString()
          });

            IEnumerable<SelectListItem> authorsList = authors
       .Select(u => new SelectListItem
       {
           Text = u.firstName + u.lastName,
           Value = u.Id.ToString()
       });

            ViewBag.CategoryList = CategoryList;

            ViewBag.PublisherList = publisherList;

            ViewBag.AuthorList = authorsList;

            if(id == null || id == 0)
            {
                ViewBag.Id = 0;
            }

            else
            {
                ViewBag.Id = id;

                Book book = await _unitOfWork.bookRepo.GetAsync(u => u.Id ==id);
                return View(book);

            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Book book , IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"imgs\books");

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                book.imgUrl = @"\imgs\books\" + fileName;

            }
            if (book.Id == 0)
            {
                
                await _unitOfWork.bookRepo.CreateAsync(book);
                await _unitOfWork.saveAsync();
                TempData["Success"] = "Book Added Successfully";
                return RedirectToAction("Index");
            }

            else
            {

                await _unitOfWork.bookRepo.UpdateAsync(book);
                await _unitOfWork.saveAsync();
                TempData["Success"] = "Book Updated Successfully";
                return RedirectToAction("Index");


            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("Index");
        }

    }
}
