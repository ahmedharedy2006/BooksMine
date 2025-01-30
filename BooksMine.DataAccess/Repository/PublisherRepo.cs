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
    public class PublisherRepo : Repository<Publisher>, IPublisherRepo
    {
        private readonly AppDbContext _db;
        public PublisherRepo(AppDbContext db) : base(db) 
        {
            _db = db;
        }
        public async Task UpdateAsync(Publisher publisher)
        {
            _db.publishers.Update(publisher);
        }
    }
}
