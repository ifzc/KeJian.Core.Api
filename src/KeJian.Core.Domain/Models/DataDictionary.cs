using System.ComponentModel.DataAnnotations;

namespace KeJian.Core.Domain.Models
{
    public class DataDictionary
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

    }
}
