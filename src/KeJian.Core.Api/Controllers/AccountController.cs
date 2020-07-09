using System.Threading.Tasks;
using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeJian.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginApplication _loginApplication;

        public AccountController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;
        }

        /// <summary>
        ///     获取 🔑 Token 
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<string> LoginAsync(LoginInputDto inputDto)
        {
            return await _loginApplication.LoginAsync(inputDto);
        }
    }
}