﻿using TaxiCompany.Core.Enums;

namespace TaxiCompany.Application.Models.Document;

public class DocumentResponseModel : BaseResponseModel
{
    public DocumentType DocumentType { get; set; }

    public string Series { get; set; }

    public string Num { get; set; }

    public string PINFL { get; set; }
}
