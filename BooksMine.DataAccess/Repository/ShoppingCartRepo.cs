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
    public class ShoppingCartRepo : Repository<ShoppingCart>, IShoppingCartRepo
    {
        private readonly AppDbContext _db;

        public ShoppingCartRepo(AppDbContext db):base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(ShoppingCart shoppingCart)
        {
            _db.shoppingCarts.Update(shoppingCart);
        }
    }
}
