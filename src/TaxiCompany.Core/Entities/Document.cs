using TaxiCompany.Core.Common;
using TaxiCompany.Core.Enums;

namespace TaxiCompany.Core.Entities;

public class Document : BaseEntity, IAuditedEntity
{
    public DocumentType DocumentType { get; set; }

    public string Series { get; set; }

    public string Num { get; set; }

    public string PINFL { get; set; }

    public User User { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
