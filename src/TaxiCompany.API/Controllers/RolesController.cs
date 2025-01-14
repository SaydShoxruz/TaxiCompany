using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services.Impl;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.Application.Models.Role;

namespace TaxiCompany.API.Controllers;

public class RolesController : ApiController
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<RoleResponseModel>>.Success(
            await _roleService.GetByIdAsync(id)));
    }

    [HttpPost]
    //[AllowAnonymous]
    public async Task<IActionResult> CreateAsync(CreateRoleModel createRoleModel)
    {
        return Ok(ApiResult<CreateRoleResponseModel>.Success(
            await _roleService.CreateAsync(createRoleModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateRoleModel updateRoleModel)
    {
        return Ok(ApiResult<UpdateRoleResponseModel>.Success(
            await _roleService.UpdateAsync(id, updateRoleModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _roleService.DeleteAsync(id)));
    }
}
