using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksMine.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]

        public string name { get; set; }

        [Required]
        [StringLength(20)]

        public string phone { get; set; }

        [StringLength(254)]
        [Required]
        public string email { get; set; }

        [Required]
        [StringLength(200)]

        public string address { get; set; }

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
