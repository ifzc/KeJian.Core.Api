using System;
using KeJian.Core.Library.EntityFrameworkCore;

namespace KeJian.Core.Domain.Models
{
    public class Team : Entity
    {
        /// <summary>
        ///     图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     添加时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}