using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KeJian.Core.Domain.Models.Base
{
    public class Entity
    {
        [Key] 
        public int Id { get; set; }

        [JsonIgnore] 
        public bool IsDeleted { get; set; }
    }
}