using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace KeJian.Core.Domain.Models.Base
{
    public class Entity : Entity<int>
    {
    }

    public class Entity<T>
    {
        [Key]
        public T Id { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
