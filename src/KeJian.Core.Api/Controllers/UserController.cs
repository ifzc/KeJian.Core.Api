using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeJian.Core.Domain.Models;
using KeJian.Core.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly DefaultDbContext _dbContext;

        public UserController(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<User>> GetAsync()
        {
            var list = await _dbContext.User
                .Where(u => !u.IsDeleted)
                .ToListAsync();

            return list;
        }

        /// <summary>
        /// 用户详情
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<bool> Update(User user)
        {
            _dbContext.Update(user);
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }
        
        /// <summary>
        /// 创建or修改 用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<User> CreateOrUpdateAsync(User user)
        {
            if (user.Id == 0)
            {
                user.CreateTime = DateTime.Now;
                var entity = await _dbContext.AddAsync(user);
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

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            var user = new User { Id = id, IsDeleted = true };
            _dbContext.Entry(user).Property(u => u.IsDeleted).IsModified = true;
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }
    }
}