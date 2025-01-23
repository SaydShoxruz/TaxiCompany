using Microsoft.AspNetCore.Http;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.CarsOwner;
using TaxiCompany.Application.Models.Client;
using TaxiCompany.Application.Models.Employee;
using TaxiCompany.Application.Models.Users;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.Core.Entities;
using TaxiCompany.Core.Enums;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.Application.Services.Impl;

public partial class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserFactory _userFactory;
    private readonly IClientService _clientService;
    private readonly IEmployeeService _employeeService;
    private readonly IDriverService _driverService;

    public UserService(
        IUserRepository userRepository,
        IUserFactory userFactory,
        IClientService clientService,
        IEmployeeService employeeService,
        IDriverService driverService)
    {
        _userRepository = userRepository;
        _userFactory = userFactory;
        _clientService = clientService;
        _employeeService = employeeService;
        _driverService = driverService;

    }

    public async ValueTask<UserDto> CreateUserAsync(
        UserForCreationDto userForCreationDto)
    {
        ValidateUserForCreationDto(userForCreationDto);

        var newUser = _userFactory
            .MapToUser(userForCreationDto);

        var addedUser = await _userRepository
            .InsertAsync(newUser);
        return _userFactory.MapToUserDto(addedUser);
    }

    public async Task CreateByRole(UserDto userDto)
    {

        if (userDto.role == UserRole.Client)
        {
            await _clientService.CreateAsync(new CreateClientModel { UserId = userDto.id });
        }
        else if (userDto.role == UserRole.Employee)
        {
            await _employeeService.CreateAsync(new CreateEmployeeModel { UserId = userDto.id });
        }
        else if (userDto.role == UserRole.Driver)
        {
            await _driverService.CreateAsync(new CreateDriverModel { UserId = userDto.id });
        }
    }

    public IQueryable<User> RetrieveUsers()
    {
        var users = _userRepository.SelectAll();

        return users;
    }

    public async ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId)
    {
        ValidateUserId(userId);

        var storageUser = await _userRepository
            .SelectByIdWithDetailsAsync(
                expression: user =>
                    user.Id == userId);

        ValidateStorageUser(storageUser, userId);

        return this.MapToUserDto(storageUser);
    }

    public async ValueTask<UserDto> ModifyUserAsync(
        UserForModificationDto userForModificationDto)
    {
        ValidateUserForModificationDto(userForModificationDto);

        var storageUser = await _userRepository
            .SelectByIdWithDetailsAsync(
                expression: user =>
                    user.Id == userForModificationDto.userId);

        ValidateStorageUser(storageUser, userForModificationDto.userId);

        _userFactory.MapToUser(storageUser, userForModificationDto);

        var modifiedUser = await _userRepository
            .UpdateAsync(storageUser);

        return _userFactory.MapToUserDto(modifiedUser);
    }

    public async ValueTask<UserDto> RemoveUserAsync(Guid userId)
    {
        ValidateUserId(userId);

        var storageUser = await _userRepository
            .SelectByIdAsync(userId);

        ValidateStorageUser(storageUser, userId);

        var removedUser = await _userRepository
            .DeleteAsync(storageUser);

        return _userFactory.MapToUserDto(removedUser);
    }

    private UserDto MapToUserDto(User user)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.LastName!,
            user.PhoneNumber,
            user.Email,
            user.Role);
    }
}