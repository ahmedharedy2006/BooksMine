using BooksMine.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.Models.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [ForeignKey("book")]
        public int bookId { get; set; }

        public Book book { get; set; }
        [Range(1, 1000 , ErrorMessage ="Please Enter A Value Between 1 And 1000")]
        public int Count { get; set; }

        [NotMapped]
        public BooksViewModel booksViewModel { get; set; }
    }
}
