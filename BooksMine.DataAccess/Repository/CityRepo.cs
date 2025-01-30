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
    public class CityRepo : Repository<City>, ICityRepo
    {
        private readonly AppDbContext _db;
        public CityRepo(AppDbContext db) : base(db) 
        {
            _db = db;
        }
        public async Task UpdateAsync(City city)
        {
            _db.cities.Update(city);
        }
    }
}
