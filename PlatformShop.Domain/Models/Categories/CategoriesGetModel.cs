
namespace PlatformShop.Domain.Models.Categories
{
    public record CategoriesGetModel : CategoriesModel
    {
        public int CategoryID { get; set; }
       
        public DateTime CreationDate { get; set; }

        
    }
}
