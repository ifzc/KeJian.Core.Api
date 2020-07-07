using System;
using System.Security.Claims;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Configs;
using KeJian.Core.Domain.Dto;
using KeJian.Core.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using KeJian.Core.Library.Exception;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Application
{
    public class LoginApplication : ILoginApplication
    {
        private readonly JwtSecurityOption _jwtOption;
        private readonly DefaultDbContext _dbContext;

        public LoginApplication(IServiceProvider serviceProvider, IOptions<JwtSecurityOption> option)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
            _jwtOption = option.Value;
        }

        public async Task<string> LoginAsync(LoginInputDto inputDto)
        {
            var user = await _dbContext.User
                .Where(u => !u.IsDeleted)
                .Where(u => u.IsAction)
                .Where(u => u.LoginName == inputDto.LoginName.Trim())
                .Where(u => u.Password == inputDto.Password.Trim())
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new StringResponseException("用户名或密码错误！");
            }

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
