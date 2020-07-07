using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KeJian.Core.Domain.Models;

namespace KeJian.Core.Application.Interface
{
    public interface IUserApplication
    {
        Task<List<User>> GetAsync();

        Task<User> Details(int id);

        Task<User> CreateOrUpdateAsync(User user);

        Task<bool> DeleteAsync(int id);
    }
}
