namespace KeJian.Core.Library.EntityFrameworkCore
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
