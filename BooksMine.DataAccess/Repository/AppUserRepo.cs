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
    public class AppUserRepo : Repository<AppUser>, IAppUserRepo
    {
        private readonly AppDbContext _db;

        public AppUserRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
