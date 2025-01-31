using BooksMine.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.DataAccess.Repository.interfaces
{
    public interface IShoppingCartRepo : IRepository<ShoppingCart>
    {
        Task UpdateAsync(ShoppingCart shoppingCart);
    }
}
