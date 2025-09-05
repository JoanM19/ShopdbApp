

namespace PlatformShop.Domain.Models.Employees
{
    public record EmployeesUpdateModel : EmployeesModel
    {
        public int Empid { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyUser { get; set; }
    }
}
