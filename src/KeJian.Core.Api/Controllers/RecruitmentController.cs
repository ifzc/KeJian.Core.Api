using System.Collections.Generic;
using System.Threading.Tasks;
using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeJian.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentController : ControllerBase
    {
        private readonly IRecruitmentApplication _application;

        public RecruitmentController(IRecruitmentApplication application)
        {
            _application = application;
        }

        /// <summary>
        ///     招聘列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Recruitment>> GetAsync()
        {
            return await _application.GetAsync();
        }

        /// <summary>
        ///     招聘列表 筛选
        /// </summary>
        /// <param name="type">类型： 1：研发类 2：服务类 3：营销类</param>
        /// <returns></returns>
        [HttpGet("/Type")]
        public async Task<List<Recruitment>> GetByTypeAsync(int type)
        {
            return await _application.GetByTypeAsync(type);
        }

        /// <summary>
        ///     招聘详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Recruitment> GetAsync(int id)
        {
            return await _application.GetAsync(id);
        }

        /// <summary>
        ///     创建or修改 招聘
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<Recruitment> CreateOrUpdateAsync(Recruitment input)
        {
            return await _application.CreateOrUpdateAsync(input);
        }

        /// <summary>
        ///     删除招聘
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _application.DeleteAsync(id);
        }
    }
}