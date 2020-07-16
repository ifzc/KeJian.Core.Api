using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KeJian.Core.Library.EntityFrameworkCore
{
    public class Entity : ISoftDelete
    {
        [Key] 
        public int Id { get; set; }

        [JsonIgnore] 
        public bool IsDeleted { get; set; }
    }
}