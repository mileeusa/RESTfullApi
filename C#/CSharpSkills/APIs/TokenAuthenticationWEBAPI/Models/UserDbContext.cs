using Microsoft.EntityFrameworkCore;

namespace TokenAuthenticationWEBAPI.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
        {
        }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserMaster> UserMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserID);

                entity.Property(e => e.UserName)
                      .HasMaxLength(50)
                      .IsRequired(false);

                entity.Property(e => e.UserPassword)
                      .HasMaxLength(50)
                      .IsRequired(false);

                entity.Property(e => e.UserRoles)
                      .HasMaxLength(500)
                      .IsRequired(false);

                entity.Property(e => e.UserEmailID)
                      .HasMaxLength(100)
                      .IsRequired(false);
            });
        }
    }
}
