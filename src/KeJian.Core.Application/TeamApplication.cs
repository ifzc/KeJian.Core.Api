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
    public class TeamApplication : IBaseApplication<Team>
    {
        private readonly DefaultDbContext _dbContext;

        public TeamApplication(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
        }

        public async Task<List<Team>> GetAsync()
        {
            return await _dbContext.Team
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.CreateTime)
                .ToListAsync();
        }

        public async Task<Team> GetAsync(int id)
        {
            var entity = await _dbContext.Team
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            return entity;
        }

        public async Task<Team> CreateOrUpdateAsync(Team input)
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
            var entity = new Team {Id = id, IsDeleted = true};
            _dbContext.Entry(entity).Property(e => e.IsDeleted).IsModified = true;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}