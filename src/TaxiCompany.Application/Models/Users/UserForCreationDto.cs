using TaxiCompany.Core.Enums;

namespace TaxiCompany.Application.Models.Users;

public record UserForCreationDto(
    string firstName,
    string? lastName,
    string phoneNumber,
    string email,
    string password,
    UserRole role);