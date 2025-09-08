

namespace PlatformShop.Domain.Models.Categories
{
    public record CategoriesCreateModel : CategoriesModel
    {
       
        public DateTime CreationDate { get; set; }

        public int CreationUser { get; set; } 
    }
}
