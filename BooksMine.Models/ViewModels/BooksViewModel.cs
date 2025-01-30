using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.Models.ViewModels
{
    public class BooksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int NoInStock { get; set; }

        public string PublisherName { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }
    }
}
