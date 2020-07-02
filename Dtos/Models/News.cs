using System;
using System.ComponentModel.DataAnnotations;

namespace KeJian.Core.Api.Dtos.Models
{
    public class News
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 类型 1：新闻咨询 2：行业动态
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

    }
}
