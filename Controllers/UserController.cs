using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeJian.Core.Api.Dtos.Models;
using KeJian.Core.Api.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Api.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DefaultDbContext _dbContext;

        public UserController(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
        }

        [HttpGet]
        public async Task<List<User>> GetAsync()
        {
            var list = await _dbContext.User.ToListAsync();
            return list;
        }
    }
}