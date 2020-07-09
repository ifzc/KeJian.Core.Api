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
    public class DataDictionaryController : ControllerBase
    {
        private readonly IDataDictionaryApplication _application;

        public DataDictionaryController(IDataDictionaryApplication application)
        {
            _application = application;
        }

        /// <summary>
        ///     数据字典列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<DataDictionary>> GetAsync()
        {
            return await _application.GetAsync();
        }

        /// <summary>
        ///     数据字典指定列表
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<DataDictionary>> GetAsync(List<string> keys)
        {
            return await _application.GetAsync(keys);
        }

        /// <summary>
        ///     数据字典详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<DataDictionary> GetAsync(int id)
        {
            return await _application.GetAsync(id);
        }

        /// <summary>
        ///     创建或修改数据字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<DataDictionary> CreateOrUpdateAsync(DataDictionary input)
        {
            return await _application.CreateOrUpdateAsync(input);
        }

        /// <summary>
        ///     删除数据字典
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