using System;
using KeJian.Core.Library.EntityFrameworkCore;

namespace KeJian.Core.Domain.Models
{
    public class News : Entity
    {
        /// <summary>
        ///     标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        ///     类型 1：新闻咨询 2：行业动态
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        ///     内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     修改时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}