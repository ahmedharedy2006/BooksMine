using BooksMine.DataAccess.Repository.interfaces;
using BooksMine.Models.Models;
using BooksMineWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.DataAccess.Repository
{
    public class OrderHeaderRepo : Repository<OrderHeader>, IOrderHeaderRepo
    {
        private readonly AppDbContext _db;
        public OrderHeaderRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(OrderHeader orderHeader)
        {
            _db.orderHeaders.Update(orderHeader);
        }
    }
}
