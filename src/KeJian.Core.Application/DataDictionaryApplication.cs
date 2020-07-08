using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Models;
using KeJian.Core.EntityFramework;
using KeJian.Core.Library.Exception;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Application
{
    public class DataDictionaryApplication : IDataDictionaryApplication
    {
        private readonly DefaultDbContext _dbContext;

        public DataDictionaryApplication(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService<DefaultDbContext>();
        }

        public async Task<List<DataDictionary>> GetAsync()
        {
            return await _dbContext.DataDictionary
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<DataDictionary>> GetAsync(string keys)
        {
            var keyList = keys.Split(',');
            var entity = await _dbContext.DataDictionary
                .Where(c => keyList.Contains(c.Key))
                .ToListAsync();

            return entity;
        }

        public async Task<DataDictionary> GetAsync(int id)
        {
            var entity = await _dbContext.DataDictionary
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            return entity;
        }

        public async Task<DataDictionary> CreateOrUpdateAsync(DataDictionary input)
        {
            if (input.Id == 0)
            {
                var ex = await _dbContext.DataDictionary.AnyAsync(d => !d.IsDeleted && d.Key == input.Key);
                if (ex) throw new StringResponseException("key 已存在！");

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
            var entity = new DataDictionary {Id = id, IsDeleted = true};
            _dbContext.Entry(entity).Property(e => e.IsDeleted).IsModified = true;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}