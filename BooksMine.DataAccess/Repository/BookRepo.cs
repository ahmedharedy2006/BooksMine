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
    public class BookRepo : Repository<Book>, IBookRepo
    {
        private readonly AppDbContext _db;

        public BookRepo(AppDbContext db) : base(db) 
        {
            _db = db;
        }
        public async Task UpdateAsync(Book book)
        {
            _db.Books.Update(book);
        }
    }
}
