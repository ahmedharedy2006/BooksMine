using BooksMine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.DataAccess.Repository.interfaces
{
    public interface ICityRepo : IRepository<City>
    {
        Task UpdateAsync(City city);

    }
}
