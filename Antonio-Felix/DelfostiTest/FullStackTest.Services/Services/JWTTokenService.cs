using FullStackTest.Services.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FullStackTest.Services.Services
{
    public interface IJWTTokenService
    {
        string GetJwtSecurityToken(User user);
    }

    public class JWTTokenService(IConfiguration Configuration) : IJWTTokenService
    {
        public string GetJwtSecurityToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:Key")!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
                {
                    new Claim("Name", user.FullName, ClaimValueTypes.String, "User Test"),
                    new Claim("Email", user.Email, ClaimValueTypes.String, "user@test.com"),
                    new Claim("Role", user.RoleId.ToString(), ClaimValueTypes.String, "None")
                };

            var token = new JwtSecurityToken(
                Configuration.GetValue<string>("Jwt:Issuer"),
                Configuration.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
