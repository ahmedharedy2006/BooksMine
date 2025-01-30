using System.ComponentModel.DataAnnotations;

namespace BooksMine.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]

        public string name { get; set; }

        [StringLength(1000)]

        public string description { get; set; }
    }
}
