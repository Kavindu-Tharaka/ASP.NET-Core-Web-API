using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ResturentAPI.Data
{
    public class Resturant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
