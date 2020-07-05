using KeJian.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KeJian.Core.EntityFramework
{
    public class DefaultDbContext : DbContext
    {
        public DbSet<Message> Message { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Recruitment> Recruitment { get; set; }

        public DbSet<Case> Case { get; set; }

        public DbSet<Team> Team { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<DataDictionary> DataDictionary { get; set; }

        public DbSet<Honor> Honor { get; set; }

        public DbSet<Study> Study { get; set; }

        public DbSet<Enterprise> Enterprise { get; set; }

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
    }
}
