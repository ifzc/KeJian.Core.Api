using System.Threading.Tasks;
using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeJian.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginApplication _loginApplication;

        public LoginController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;
        }

        [HttpPost]
        [Authorize]
        public async Task<string> LoginAsync(LoginInputDto inputDto)
        {
            return await _loginApplication.LoginAsync(inputDto);
        }
    }
}