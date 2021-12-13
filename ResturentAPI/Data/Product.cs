using System.ComponentModel.DataAnnotations;

namespace ResturentAPI.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Range(0, 99999)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required]
        [Range(0, 9999)]
        public int UnitsInStock { get; set; }

        public int ResturantId { get; set; }    //1 to M relationship
        public Resturant Resturant { get; set; } 
        
        public int ProductCategoryId { get; set; }  //1 to M relationship
        public ProductCategory ProductCategory { get; set; }

    }
}
