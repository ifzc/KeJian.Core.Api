using System;
using System.ComponentModel.DataAnnotations;

namespace KeJian.Core.Api.Dtos.Models
{
    public class Team
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
