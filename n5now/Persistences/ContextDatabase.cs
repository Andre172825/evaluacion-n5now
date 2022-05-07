using Microsoft.EntityFrameworkCore;
using n5now.Models;

namespace n5now.Persistences
{
    public class ContextDatabase: DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Permissions> Permissions => Set<Permissions>();
        public DbSet<PermissionTypes> PermissionTypes => Set<PermissionTypes>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissions>().ToTable("Permissions");
            modelBuilder.Entity<PermissionTypes>().ToTable("PermissionTypes");
        }
    }
}