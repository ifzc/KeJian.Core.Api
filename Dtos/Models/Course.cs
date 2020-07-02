using System.ComponentModel.DataAnnotations;

namespace KeJian.Core.Api.Dtos.Models
{
    public class Course
    {

        /// <summary>
        /// 历程ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
