using BooksMine.DataAccess.Repository.interfaces;
using BooksMine.Models;
using BooksMineWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.DataAccess.Repository
{
    public class CategoryRepo : Repository<Category> , ICategoryRepo
    {
        private readonly AppDbContext _db;
        public CategoryRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(Category category)
        {
            _db.Categories.Update(category);

        }
    }
}
