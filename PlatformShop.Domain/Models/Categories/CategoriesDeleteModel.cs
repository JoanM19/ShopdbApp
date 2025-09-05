

namespace PlatformShop.Domain.Models.Categories
{
    public record CategoriesDeleteModel 
    {
        public int CategoryID { get; set; }
        public DateTime Deletion_Date { get; set; }
        public int Deletion_User { get; set; }
    }
}
