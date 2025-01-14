using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities;

public class Client : BaseEntity, IAuditedEntity
{
    public User User { get; set; }

    public bool SubscriptionStatus { get; set; } = false;

    public decimal AccountWallet { get; set; } = 0;

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
