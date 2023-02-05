using Microsoft.EntityFrameworkCore;
using OnlineSocial.UserProfile.Model;

namespace OnlineSocial.UserProfile.Infrastructure.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserInfo>(entity => entity.ToTable("user"));
        }
    }
}
