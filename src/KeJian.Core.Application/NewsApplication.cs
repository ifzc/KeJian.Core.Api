using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Models;
using KeJian.Core.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Application
{
    public class NewsApplication : INewsApplication
    {
        private readonly DefaultDbContext _dbContext;

        public NewsApplication(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
        }

        public async Task<List<News>> GetAsync()
        {
            return await _dbContext.News
                .Where(c => !c.IsDeleted)
                .OrderByDescending(_ => _.CreateTime)
                .ToListAsync();
        }

        public async Task<List<News>> GetAsync(int type, int count)
        {
            return await _dbContext.News
                .Where(c => c.Type == type)
                .Where(c => !c.IsDeleted)
                .OrderByDescending(_ => _.CreateTime)
                .Take(count)
                .ToListAsync();
        }

        public async Task<News> GetAsync(int id)
        {
            var entity = await _dbContext.News
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            return entity;
        }

        public async Task<News> CreateOrUpdateAsync(News input)
        {
            input.CreateTime = DateTime.Now;

            if (input.Id == 0)
            {
                var entity = await _dbContext.AddAsync(input);
                await _dbContext.SaveChangesAsync();
                return entity.Entity;
            }

            _dbContext.Update(input);
            await _dbContext.SaveChangesAsync();
            return input;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = new News {Id = id, IsDeleted = true};
            _dbContext.Entry(entity).Property(e => e.IsDeleted).IsModified = true;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}