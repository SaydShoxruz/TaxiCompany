using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services.Impl;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.Application.Models.CarsOwner;

namespace TaxiCompany.API.Controllers;

public class DriverController : ApiController
{
    private readonly IDriverService _driverService;

    public DriverController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<DriverResponseModel>>.Success(
            await _driverService.GetAllByPersonIdAsync(id)));
    }

    //[HttpPost]
    ////[AllowAnonymous]
    //public async Task<IActionResult> CreateAsync(CreateDriverModel createCarsOwnerModel)
    //{
    //    return Ok(ApiResult<CreateCarsOwnerResponseModel>.Success(
    //        await _driverService.CreateAsync(createCarsOwnerModel)));
    //}

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _driverService.DeleteAsync(id)));
    }
}
