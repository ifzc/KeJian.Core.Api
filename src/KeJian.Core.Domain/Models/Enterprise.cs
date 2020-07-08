using System;
using System.ComponentModel.DataAnnotations;

namespace KeJian.Core.Domain.Models
{
    public class Enterprise
    {
        /// <summary>
        ///     荣誉ID
        /// </summary>
        [Key]
        public int Id { get; set; }

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

        public bool IsDeleted { get; set; }
    }
}