using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities;

public class Car : BaseEntity, IAuditedEntity
{
    public string Model { get; set; }

    public bool IsFree { get; set; } = false;

    public CarsOwner CarsOwner { get; set; }

    public List<Company> Companies { get; } = new List<Company>();

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
