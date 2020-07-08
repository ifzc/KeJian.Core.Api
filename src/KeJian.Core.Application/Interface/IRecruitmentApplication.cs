using System.Collections.Generic;
using System.Threading.Tasks;
using KeJian.Core.Domain.Models;

namespace KeJian.Core.Application.Interface
{
    public interface IRecruitmentApplication : IBaseApplication<Recruitment>
    {
        Task<List<Recruitment>> GetByTypeAsync(int type);
    }
}