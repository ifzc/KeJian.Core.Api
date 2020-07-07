using System.Threading.Tasks;
using KeJian.Core.Domain.Dto;

namespace KeJian.Core.Application.Interface
{
    public interface ILoginApplication
    {
        Task<string> LoginAsync(LoginInputDto inputDto);
    }
}
