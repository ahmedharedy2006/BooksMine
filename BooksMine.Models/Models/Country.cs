using System.ComponentModel.DataAnnotations;

namespace BooksMine.Models
{
    public class Country
    {
        public int Id { get; set; }

        [StringLength(150)]
        [Required]
         public string name { get; set; }


    }
}
