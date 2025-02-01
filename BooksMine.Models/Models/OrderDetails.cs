using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.Models.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("OrderHeader")]
        public int orderHeaderId { get; set; }

        public OrderHeader orderHeader { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int bookId { get; set; }

        public Book book { get; set; }

        public int count { get; set; }

        public double price { get; set; }
    }
}
