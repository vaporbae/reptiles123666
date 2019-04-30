namespace ReptoRepto.Infrastucture.Authentication
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using ReptoRepto.Application.Exceptions;
    using ReptoRepto.Application.Helpers;
    using ReptoRepto.Application.Interfaces;
    using ReptoRepto.Application.Models;
    using ReptoRepto.Persistence;

    public class JwtService : IJwtService
    {
        private readonly ReptoReptoDbContext _context;
        private readonly IOptions<JwtSettings> _jwt;
        public JwtService(ReptoReptoDbContext context, IOptions<JwtSettings> jwt)
        {
            _context = context;
            _jwt = jwt;
        }
        public async Task<IActionResult> Login(LoginSignInModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login.Equals(model.Login));
            if (user == null)
            {
                throw new NotFoundException(model.Login, -1);
            }
            else if (!PasswordHelper.ValidatePassword(model.Password, user.Password))
            {
                return new UnauthorizedResult();
            }

            return new ObjectResult(GenerateJwtToken(model.Login, user.Id, true));
        }

        private JwtTokenModel GenerateJwtToken(string email, int id, bool isAdmin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Value.Key);

            var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.UserData, id.ToString())
                });
            if (isAdmin)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                claims.AddClaim(new Claim(ClaimTypes.Role, "SuperAdmin"));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var result = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtTokenModel { Token = tokenHandler.WriteToken(result), ValidTo = result.ValidTo };
        }
        
    }
}
