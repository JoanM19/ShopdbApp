

namespace PlatformShop.Domain.Models.Employees
{
    public record EmployeesDeleteModel
    {
        public int Empid { get; set; }
        public DateTime DeleteDate { get; set; }
        public int DeleteUser { get; set; }
    }
}
