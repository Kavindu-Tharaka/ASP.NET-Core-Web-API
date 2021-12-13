using System.ComponentModel.DataAnnotations;

namespace ResturentAPI.Handlers.Resturant.AddResturant
{
    public class ResturantModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }


        //public ICollection<ProductModel> Products { get; set; }    //mehema ona wenawada?  Entity class eke thiyana ekata anurupawa

        //resturant ID eka endpoint ekata dunnama ee resturant ekata adaala Products tika ganna ona unoth? query dekak gahanna oanda?

        //meka thibboth resturant ekak add karanna yaddi Products array ekakuth add karanna wenawa

        //therefore, wena wenama models use kranna add, read wage ewata awashya wena widiyata
    }
}
