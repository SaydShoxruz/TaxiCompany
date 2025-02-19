﻿namespace TaxiCompany.Application.Models.Employee;

public class CreateEmployeeModel
{
    public string Name { get; set; }

    public Guid CompanyId { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }
}

public class CreateEmployeeResponseModel : BaseResponseModel { }