using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Models;
using KeJian.Core.EntityFramework;
using KeJian.Core.Library.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly DefaultDbContext _dbContext;

        public UserApplication(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
        }

        [AllowAnonymous]
        public async Task<List<User>> GetAsync()
        {
            var list = await _dbContext.User
                .Where(u => !u.IsDeleted)
                .ToListAsync();

            return list;
        }

        public async Task<User> Details(int id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateOrUpdateAsync(User user)
        {
            if (user.Id == 0)
            {
                var ise = await _dbContext.User.FirstOrDefaultAsync(u => u.LoginName == user.LoginName);
                if (ise != null)
                {
                    throw new StringResponseException("用户名已被占用了！");
                }

                user.Password = GetMd5(user.Password);
                user.CreateTime = DateTime.Now;
                var entity = await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return entity.Entity;
            }
            else
            {
                if (user.LoginName == "admin")
                {
                    throw new StringResponseException("这个可不能改哦！");
                }

                user.Password = GetMd5(user.Password);
                _dbContext.Update(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == id);
            if (user.LoginName == "admin")
            {
                throw new StringResponseException("这个可不能删哦！");
            }
            _dbContext.Entry(user).Property(u => u.IsDeleted).IsModified = true;
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        // 升级地狱难度 = 无解
        private const string key = "#kejian$*@!";

        private string GetMd5(string value)
        {
            using var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value + key));
            var sBuilder = new StringBuilder();
            foreach (var b in data)
            {
                sBuilder.Append(b.ToString("x2"));
            }

            var hash = sBuilder.ToString();
            return hash;
        }
    }
}
