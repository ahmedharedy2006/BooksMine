using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksMine.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string firstName { get; set; }

        [Required]
        [StringLength(100)]
        public string lastName { get; set; }

        [ForeignKey(nameof(city))]
        [Required]
        public int cityId { get; set; }
        public City city { get; set; }

        [ForeignKey(nameof(country))]
        [Required]

        public int countryId { get; set; }
        public Country country { get; set; }

    }
}
