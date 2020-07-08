using System;
using System.ComponentModel.DataAnnotations;

namespace KeJian.Core.Domain.Models
{
    public class Case
    {
        /// <summary>
        ///     案例ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     案例图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        ///     案例标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     案例内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     案例详情
        /// </summary>
        public string Del { get; set; }

        /// <summary>
        ///     修改时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}