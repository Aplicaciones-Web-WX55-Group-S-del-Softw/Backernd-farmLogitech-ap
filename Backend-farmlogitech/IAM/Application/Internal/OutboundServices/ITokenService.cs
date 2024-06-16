using Backend_farmlogitech.IAM.Domain.Model.Aggregates;

namespace Backend_farmlogitech.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}