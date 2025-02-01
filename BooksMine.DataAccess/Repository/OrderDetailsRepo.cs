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
    public class OrderDetailsRepo : Repository<OrderDetails>, IOrderDetailsRepo
    {
        private readonly AppDbContext _db;
        public OrderDetailsRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(OrderDetails orderDetails)
        {
            _db.orderDetails.Update(orderDetails);
        }
    }
}
