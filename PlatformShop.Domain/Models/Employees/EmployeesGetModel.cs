
namespace PlatformShop.Domain.Models.Employees
{
    public record EmployeesGetModel : EmployeesModel
    {
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
    }
}
