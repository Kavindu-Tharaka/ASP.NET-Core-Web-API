using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ResturentAPI.Data
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
