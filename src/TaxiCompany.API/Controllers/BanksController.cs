using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Services.Interfaces;

namespace TaxiCompany.API.Controllers;

[Authorize(Roles = "Client")]
public class BanksController : ApiController
{
    private readonly IBankService _bankService;

    public BanksController(IBankService bankService)
    {
        _bankService = bankService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync()
    {
        return Ok(ApiResult<IEnumerable<BankResponseModel>>.Success(
            await _bankService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateBankModel createBankModel)
    {
        return Ok(ApiResult<CreateBankResponseModel>.Success(
            await _bankService.CreateAsync(createBankModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateBankModel updateBankModel)
    {
        return Ok(ApiResult<UpdateBankResponseModel>.Success(
            await _bankService.UpdateAsync(id, updateBankModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _bankService.DeleteAsync(id)));
    }
}
