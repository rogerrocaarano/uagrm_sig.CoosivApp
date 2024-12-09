using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Domain.Services;

namespace uagrm_sig.CoosivApp.Infrastructure.JwtBearer;

public class AuthService(string privateKey) : ITokenGenService
{
    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey)),
            SecurityAlgorithms.HmacSha256Signature
        );
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddDays(1),
            Subject = GenerateClaims(user)
        };
        
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
    
    private static ClaimsIdentity GenerateClaims(User user)
    {
        var ci = new ClaimsIdentity();
        
        ci.AddClaim(new Claim("id", user.Id.ToString()));
        ci.AddClaim(new Claim("username", user.Username));

        return ci;
    }
}