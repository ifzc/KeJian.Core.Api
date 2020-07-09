using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Models;
using KeJian.Core.EntityFramework;
using KeJian.Core.Library.Exception;
using KeJian.Core.Library.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Application
{
    public class UserApplication : IBaseApplication<User>
    {
        private readonly DefaultDbContext _dbContext;

        public UserApplication(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
        }

        public async Task<List<User>> GetAsync()
        {
            var list = await _dbContext.User
                .Where(u => !u.IsDeleted)
                .OrderByDescending(u => u.CreateTime)
                .ToListAsync();

            return list;
        }

        public async Task<User> GetAsync(int id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateOrUpdateAsync(User input)
        {
            input.CreateTime = DateTime.Now;
            input.Password = input.Password.GetMd5();

            if (input.Id == 0)
            {
                var ise = await _dbContext.User.FirstOrDefaultAsync(u => u.LoginName == input.LoginName);
                if (ise != null) throw new StringResponseException("用户名已被占用了！");

                var entity = await _dbContext.AddAsync(input);
                await _dbContext.SaveChangesAsync();
                return entity.Entity;
            }

            if (input.LoginName == "admin") throw new StringResponseException("这个可不能改哦！");

            _dbContext.Update(input);
            await _dbContext.SaveChangesAsync();
            return input;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == id);
            if (user.LoginName == "admin") throw new StringResponseException("这个可不能删哦！");
            user.IsDeleted = true;
            _dbContext.Entry(user).Property(u => u.IsDeleted).IsModified = true;
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }
    }
}