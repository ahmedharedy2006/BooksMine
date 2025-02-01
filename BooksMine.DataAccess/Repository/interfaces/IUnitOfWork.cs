using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.DataAccess.Repository.interfaces
{
    public  interface IUnitOfWork
    {
        ICategoryRepo categoryRepo { get; }

        IBookRepo bookRepo { get; }

        IPublisherRepo publisherRepo { get; }

        IAuthorRepo authorRepo { get; }

        ICityRepo cityRepo { get; }

        ICountryRepo countryRepo { get; }

        IShoppingCartRepo shoppingCartRepo { get; }

        IOrderDetailsRepo orderDetailsRepo { get; }

        IOrderHeaderRepo orderHeaderRepo { get; }
        Task saveAsync();
        
    }
}
