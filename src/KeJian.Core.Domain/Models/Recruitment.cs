using System;
using KeJian.Core.Domain.Models.Base;

namespace KeJian.Core.Domain.Models
{
    /// <summary>
    ///     招聘信息Dto
    /// </summary>
    public class Recruitment : Entity
    {
        /// <summary>
        ///     标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     类型 1：研发类 2：服务类 3：营销类
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        ///     添加时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}