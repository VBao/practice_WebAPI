using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Api.Repository
{
    public class CustomerManagementContext:DbContext
    {
        public CustomerManagementContext(DbContextOptions<CustomerManagementContext> options) : base(options)
        {

        }

        public DbSet<Attribute> attributes { get; set; }
        public DbSet<Setting> settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>()
                .HasOne<Setting>(s => s.CustomerSetting)
                .WithMany(m => m.CustomerMaintenances)
                .HasForeignKey(s => s.SettingId);
            modelBuilder.CustomerSettingSeeder();
            modelBuilder.CustomerAttributeSeeder();
        }
    }
}
