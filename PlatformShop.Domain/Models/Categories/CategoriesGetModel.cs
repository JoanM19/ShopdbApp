
namespace PlatformShop.Domain.Models.Categories
{
    public record CategoriesGetModel : CategoriesModel
    {
        public int CategoryID { get; set; }
       
        public DateTime Creation_Date { get; set; }

        public int Creation_User { get; set; }
    }
}
