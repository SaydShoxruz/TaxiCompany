﻿using TaxiCompany.Application.Models.Users;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Authentication;

namespace TaxiCompany.Application.Services.Impl;

public class UserFactory : IUserFactory
{
    private readonly IPasswordHasher passwordHasher;

    public UserFactory(
        IPasswordHasher passwordHasher)
    {
        this.passwordHasher = passwordHasher;
    }

    public User MapToUser(
        UserForCreationDto userForCreationDto)
    {
        string randomSalt = Guid.NewGuid().ToString();

        return new User
        {
            FirstName = userForCreationDto.firstName,
            LastName = userForCreationDto.lastName,
            PhoneNumber = userForCreationDto.phoneNumber,
            Email = userForCreationDto.email,

            Salt = randomSalt,

            PasswordHash = this.passwordHasher.Encrypt(
                password: userForCreationDto.password,
                salt: randomSalt),

            Role = userForCreationDto.role
        };
    }

    public void MapToUser(
        User storageUser,
        UserForModificationDto userForModificationDto)
    {
        storageUser.FirstName = userForModificationDto.firstName ?? storageUser.FirstName;
        storageUser.LastName = userForModificationDto.lastName;
        storageUser.UpdatedAt = DateTime.UtcNow;
    }

    public UserDto MapToUserDto(User user)
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