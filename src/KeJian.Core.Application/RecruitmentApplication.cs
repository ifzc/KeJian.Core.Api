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
    public class RecruitmentApplication : IRecruitmentApplication
    {
        private readonly DefaultDbContext _dbContext;

        public RecruitmentApplication(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
        }

        public async Task<List<Recruitment>> GetAsync()
        {
            return await _dbContext.Recruitment
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Recruitment>> GetByTypeAsync(int type)
        {
            return await _dbContext.Recruitment
                .Where(c => !c.IsDeleted)
                .Where(c => c.Type == type)
                .ToListAsync();
        }

        public async Task<Recruitment> GetAsync(int id)
        {
            var entity = await _dbContext.Recruitment
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            return entity;
        }

        public async Task<Recruitment> CreateOrUpdateAsync(Recruitment input)
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
            var entity = new Recruitment {Id = id, IsDeleted = true};
            _dbContext.Entry(entity).Property(e => e.IsDeleted).IsModified = true;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}