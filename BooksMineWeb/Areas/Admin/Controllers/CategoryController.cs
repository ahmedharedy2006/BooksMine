using BooksMineWeb.Data;
using BooksMine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksMine.DataAccess.Repository.interfaces;
using BooksMine.DataAccess.Repository;

namespace BooksMineWeb.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryRepo.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid) { 
            await _categoryRepo.CreateAsync(category);
            TempData["Success"] = "Category Created Successfully";

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = await _categoryRepo.GetAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.UpdateAsync(category);

                TempData["Success"] = "Category Updated Successfully";

            }
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete (int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = await _categoryRepo.GetAsync(c => c.Id == id);
            if(category ==  null)
            {
                return NotFound();
            }
            await _categoryRepo.RemoveAsync(category);

            TempData["Success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}
