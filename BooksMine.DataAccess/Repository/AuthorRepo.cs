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
    public class AuthorRepo : Repository<Author>, IAuthorRepo
    {
        private readonly AppDbContext _db;

        public AuthorRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
       
        public async Task UpdateAsync(Author author)
        {
            _db.authors.Update(author);
        }
    }
}
