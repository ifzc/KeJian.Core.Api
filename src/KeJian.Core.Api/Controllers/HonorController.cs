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
    public class HonorController : ControllerBase
    {
        private readonly IBaseApplication<Honor> _application;

        public HonorController(IBaseApplication<Honor> application)
        {
            _application = application;
        }

        /// <summary>
        ///     荣誉列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Honor>> GetAsync()
        {
            return await _application.GetAsync();
        }

        /// <summary>
        ///     荣誉详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Honor> GetAsync(int id)
        {
            return await _application.GetAsync(id);
        }

        /// <summary>
        ///     创建或修改荣誉
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<Honor> CreateOrUpdateAsync(Honor input)
        {
            return await _application.CreateOrUpdateAsync(input);
        }

        /// <summary>
        ///     删除荣誉
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