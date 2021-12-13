using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ResturentAPI.Handlers.ProductCategory.GetAllProductCategories
{
    public class ProductCategoryModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string CategoryName { get; set; }


        //public ICollection<ProductModel> Products { get; set; }    //mehema ona wenawada?  Entity class eke thiyana ekata anurupawa

        //category ID eka endpoint ekata dunnama ee category ekata adaala Products tika ganna ona unoth? query dekak gahanna oanda?

        //meka thibboth Category ekak add karanna yaddi Products array ekakuth add karanna wenawa
    }
}
