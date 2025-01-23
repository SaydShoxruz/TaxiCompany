namespace TaxiCompany.Application.Models.Employee;

public class EmployeeResponseModel : BaseResponseModel
{
    public string Name { get; set; }

    public DateTime HireDate { get; set; }

    public DateTime? DismissalDate { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }
}
