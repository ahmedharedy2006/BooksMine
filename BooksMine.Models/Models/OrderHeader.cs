using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.Models.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public double orderTotal { get; set; }

        public DateTime ShippingDate { get; set; }

        public string? paymentStatus { get; set; }

        public string? orderStatus { get;  set; }

        public string? trackingNumber { get; set; }

        public string? carrier { get; set; }

        public DateTime paymentDate { get; set; }

        public DateOnly paymentDueDate { get; set; }

        public string? sessionId { get; set; }

        public string? paymentIntentId { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public string streetAddress { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        public string postalCode { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
