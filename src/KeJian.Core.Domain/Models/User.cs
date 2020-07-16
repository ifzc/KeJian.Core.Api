using System;
using KeJian.Core.Library.EntityFrameworkCore;

namespace KeJian.Core.Domain.Models
{
    public class User : Entity
    {
        /// <summary>
        ///     登陆名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     是否启用
        /// </summary>
        public bool IsAction { get; set; }

        /// <summary>
        ///     新增时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}