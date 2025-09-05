

namespace PlatformShop.Domain.Models.Categories
{
    public record CategoriesUpdateModel : CategoriesModel
    {
        public int CategoryID { get; set; }
        public DateTime? Modified_Date { get; set; }
        public int Modified_User { get; set; }
    }
}
