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
    public class CountryRepo : Repository<Country>, ICountryRepo
    {
        private readonly AppDbContext _db;

        public CountryRepo(AppDbContext db) : base(db) 
        {
            _db = db;
        }
        public async Task UpdateAsync(Country country)
        {
            _db.countries.Update(country);
        }
    }
}
