using BooksMine.Models;
using BooksMine.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.DataAccess.Repository.interfaces
{
    public interface IOrderHeaderRepo : IRepository<OrderHeader>
    {
        Task UpdateAsync(OrderHeader orderHeader);

    }
}
