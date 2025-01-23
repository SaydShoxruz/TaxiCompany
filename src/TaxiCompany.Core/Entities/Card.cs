using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities;

public class Card : BaseEntity, IAuditedEntity
{
    public Bank Bank { get; set; }

    public string Num { get; set; }

    public string Term { get; set; }

    public bool IsVerified { get; set; } = false;

    public decimal Balance { get; set; }

    public User User { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
