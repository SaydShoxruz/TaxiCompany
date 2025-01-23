using TaxiCompany.Core.Common;
using TaxiCompany.Core.Enums;

namespace TaxiCompany.Core.Entities;

public class Driver : BaseEntity, IAuditedEntity
{
    public int Priority { get; set; } = 100;

    public decimal Rating { get; set; } = 5.00m;

    public User User { get; set; }

    public TarifType TarifType { get; set; }

    public decimal CompanyWallet { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
