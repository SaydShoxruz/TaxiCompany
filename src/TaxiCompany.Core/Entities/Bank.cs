﻿using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities;

public class Bank : BaseEntity, IAuditedEntity
{
    public string Name { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
