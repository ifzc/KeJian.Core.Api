using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KeJian.Core.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using KeJian.Core.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using KeJian.Core.Domain.Configs;
using Microsoft.Extensions.Options;

namespace KeJian.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DefaultDbContext _dbContext;
        private readonly JwtSecurityOption _jwtOption;

        public LoginController(IServiceProvider serviceProvider, IOptions<JwtSecurityOption> option)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
            _jwtOption = option.Value;
        }

        [HttpPost]
        public async Task<string> LoginAsync(LoginInputDto inputDto)
        {
            var user = await _dbContext.User
                .Where(u => !u.IsDeleted)
                .Where(u => u.IsAction)
                .Where(u => u.LoginName == inputDto.LoginName.Trim())
                .Where(u => u.Password == inputDto.Password.Trim())
                .FirstOrDefaultAsync();

            var claims = new[]
            {
                new Claim("Id",user.Id.ToString()),
                new Claim("Name",user.LoginName)
            };
            var key = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(_jwtOption.SigningKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_jwtOption.Issuer, _jwtOption.Audience, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }
    }
}