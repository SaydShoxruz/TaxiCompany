using TaxiCompany.Core.Common;
using TaxiCompany.Core.Enums;

namespace TaxiCompany.Core.Entities;

public class User : Auditable
{
    private const int DEFAULT_EXPIRE_DATE_IN_MINUTES = 1440;

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public UserRole Role { get; set; }

    public string PasswordHash { get; set; }

    public string Salt { get; set; }

    public string? RefreshToken { get; private set; }

    public DateTime? RefreshTokenExpireDate { get; private set; }

    public void UpdateRefreshToken(
        string refreshToken,
        int expireDateInMinutes = DEFAULT_EXPIRE_DATE_IN_MINUTES)
    {
        RefreshToken = refreshToken;

        RefreshTokenExpireDate = DateTime.UtcNow
            .AddMinutes(expireDateInMinutes);
    }
}
