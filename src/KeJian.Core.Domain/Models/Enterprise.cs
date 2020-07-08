using System;
using KeJian.Core.Domain.Models.Base;

namespace KeJian.Core.Domain.Models
{
    public class Enterprise : Entity
    {
        /// <summary>
        ///     图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        ///     注释(描述)
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     添加时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}