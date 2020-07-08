using KeJian.Core.Domain.Models.Base;

namespace KeJian.Core.Domain.Models
{
    public class Course : Entity
    {
        /// <summary>
        ///     年份
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        ///     内容
        /// </summary>
        public string Content { get; set; }
    }
}