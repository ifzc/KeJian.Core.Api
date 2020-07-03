using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KeJian.Core.Domain.Models;
using KeJian.Core.EntityFramework;
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

        [HttpPut]
        public async Task<User> CreateOrUpdateAsync(User user)
        {
            if (user.Id == 0)
            {
                user.CreateTime = DateTime.Now;
                var entity = await _dbContext.User.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return entity.Entity;
            }
            else
            {
                _dbContext.Update(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
        }
    }
}