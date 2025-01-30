using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksMine.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]

        public string title { get; set; }

        [Required]
        [StringLength(1000)]

        public string description { get; set; }

        [Required]

        public double price { get; set; }

        [Required]

        public int edition { get; set; }
        [Required]

        public int noInStock { get; set; }

        [Required]
        [StringLength(100)]
        public string imgUrl { get; set; }

        [ForeignKey(nameof(author))]

        public int? authId {  get; set; }
        public Author author {  get; set; }

        [ForeignKey(nameof(publisher))]

        public int? pubId { get; set; }
        public Publisher publisher { get; set; }

        [ForeignKey(nameof(category))]

        public int? catId { get; set; }
        public Category category { get; set; }

    }
}
