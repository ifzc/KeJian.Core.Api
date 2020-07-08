using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeJian.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IBaseApplication<Course> _application;

        public CourseController(IBaseApplication<Course> application)
        {
            _application = application;
        }

        /// <summary>
        ///     发展历程列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Course>> GetAsync()
        {
            return await _application.GetAsync();
        }

        /// <summary>
        ///     发展历程详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Course> GetAsync(int id)
        {
            return await _application.GetAsync(id);
        }

        /// <summary>
        ///     创建or修改 发展历程
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Course> CreateOrUpdateAsync(Course input)
        {
            return await _application.CreateOrUpdateAsync(input);
        }

        /// <summary>
        ///     删除发展历程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _application.DeleteAsync(id);
        }
    }
}
