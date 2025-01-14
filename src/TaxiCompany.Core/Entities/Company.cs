using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities;

public class Company : BaseEntity, IAuditedEntity
{
    public string Name { get; set; }

    public decimal Comission { get; set; }

    public Bank Bank { get; set; }

    public List<Car> Cars { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
