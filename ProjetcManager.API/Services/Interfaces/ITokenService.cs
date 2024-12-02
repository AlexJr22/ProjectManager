using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetcManager.API.Services.Interfaces;

public interface ITokenService
{
    JwtSecurityToken GenerateAcessToken(IEnumerable<Claim> claims, IConfiguration _config);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToKen(string token, IConfiguration _config);
}
