using System.Collections.Generic;
using System.Threading.Tasks;
using KeJian.Core.Domain.Models;

namespace KeJian.Core.Application.Interface
{
    public interface INewsApplication : IBaseApplication<News>
    {
        Task<List<News>> GetAsync(int type, int count);
    }
}