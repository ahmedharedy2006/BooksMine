using BooksMine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.DataAccess.Repository.interfaces
{
    public interface IPublisherRepo : IRepository<Publisher>
    {
        Task UpdateAsync(Publisher publisher);

    }
}
