

namespace PlatformShop.Domain.Models.Employees
{
    public record EmployesCreateModel : EmployeesModel
    {
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
    }
}
