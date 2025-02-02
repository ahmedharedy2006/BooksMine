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

        public void UpdateStatus(int id, string Orderstatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.orderHeaders.FirstOrDefault(o => o.Id == id);
            if(orderFromDb != null)
            {
                orderFromDb.orderStatus = Orderstatus;
                if (paymentStatus != null)
                {
                    orderFromDb.paymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentIntentId(int id, string paymentIntentId, string sessionId)
        {
            var orderFromDb = _db.orderHeaders.FirstOrDefault(o => o.Id == id);
            if(!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.paymentIntentId = paymentIntentId;
                orderFromDb.paymentDate = DateTime.Now;
            }

            if(!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.sessionId = sessionId;
            }
        }
    }
}
