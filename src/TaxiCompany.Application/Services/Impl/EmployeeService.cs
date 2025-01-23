using AutoMapper;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.Application.Models.Employee;
using TaxiCompany.DataAccess.Repositories.Impl;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.Application.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public EmployeeService(IMapper mapper,
        IEmployeeRepository employeeRepository,
        IUserRepository userRepository,
        IRoleRepository roleRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<EmployeeResponseModel>> GetAll()
    {
        var employees = _employeeRepository.GetAllAsEnumurable();

        return _mapper.Map<IEnumerable<EmployeeResponseModel>>(employees);
    }

    public async Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel)
    {
        var user = await _userRepository.SelectByIdAsync(createEmployeeModel.UserId);
        var role = await _roleRepository.GetFirstAsync(cti => cti.Id == createEmployeeModel.RoleId);

        var employee = _mapper.Map<Employee>(createEmployeeModel);
        employee.User = user;
        employee.Role = role;

        return new CreateEmployeeResponseModel()
        {
            Id = (await _employeeRepository.AddAsync(employee)).Id
        };
    }

    public async Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel)
    {
        var employee = await _employeeRepository.GetFirstAsync(cti => cti.Id == id);
        _mapper.Map(employee, updateEmployeeModel);

        return new UpdateEmployeeResponseModel()
        {
            Id = (await _employeeRepository.UpdateAsync(employee)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var company = await _employeeRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _employeeRepository.DeleteAsync(company)).Id
        };
    }
}
