using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services.Impl;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.Application.Models.Company;

namespace TaxiCompany.API.Controllers;

public class CompaniesController : ApiController
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync()
    {
        return Ok(ApiResult<IEnumerable<CompanyResponseModel>>.Success(
            await _companyService.GetAll()));
    }

    [HttpPost]
    //[AllowAnonymous]
    public async Task<IActionResult> CreateAsync(CreateCompanyModel createCompanyModel)
    {
        return Ok(ApiResult<CreateCompanyResponseModel>.Success(
            await _companyService.CreateAsync(createCompanyModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateCompanyModel updateCompanyModel)
    {
        return Ok(ApiResult<UpdateCompanyResponseModel>.Success(
            await _companyService.UpdateAsync(id, updateCompanyModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _companyService.DeleteAsync(id)));
    }
}
