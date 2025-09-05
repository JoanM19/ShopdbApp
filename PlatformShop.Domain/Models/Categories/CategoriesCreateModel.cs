

namespace PlatformShop.Domain.Models.Categories
{
    public record CategoriesCreateModel : CategoriesGetModel
    {
       
        public DateTime CreationDate { get; set; }

        public int CreationUser { get; set; } 
    }
}
