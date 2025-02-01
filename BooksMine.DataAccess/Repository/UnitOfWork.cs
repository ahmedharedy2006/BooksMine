using BooksMine.DataAccess.Repository.interfaces;
using BooksMineWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public ICategoryRepo categoryRepo { get; private set; }

        public IBookRepo bookRepo { get; private set; }

        public IShoppingCartRepo shoppingCartRepo { get; private set; }

        public IPublisherRepo publisherRepo { get; private set; }

        public IAuthorRepo authorRepo { get; private set; }

        public ICityRepo cityRepo { get; private set; }

        public ICountryRepo countryRepo { get; private set; }

        public IOrderHeaderRepo orderHeaderRepo { get; private set; }

        public IOrderDetailsRepo orderDetailsRepo { get; private set; }
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            categoryRepo = new CategoryRepo(db);
            bookRepo = new BookRepo(db);
            publisherRepo = new PublisherRepo(db);
            authorRepo = new AuthorRepo(db);
            cityRepo = new CityRepo(db);
            countryRepo = new CountryRepo(db);
            shoppingCartRepo = new ShoppingCartRepo(db);
            orderHeaderRepo = new OrderHeaderRepo(db);
            orderDetailsRepo = new OrderDetailsRepo(db);
        }

        public async Task saveAsync()
        {
            _db.SaveChangesAsync();
        }
    }
}
