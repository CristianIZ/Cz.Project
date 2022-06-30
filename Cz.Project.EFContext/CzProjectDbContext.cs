using Cz.Project.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cz.Project.EFContext
{
    public class CzProjectDbContext : DbContext
    {
        public CzProjectDbContext() { }
        public CzProjectDbContext(DbContextOptions<CzProjectDbContext> options) : base(options) { }

        public DbSet<AdminUsers> AdminUsers { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<LicenseLicense> LicenseLicense { get; set; }
        public DbSet<Languaje> Languajes { get; set; }
        public DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=DESKTOP-020RVT4;Initial Catalog=Cz.Project;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<LicenseLicense>(l =>
            // {
            //     l.HasNoKey();
            // });

            ConfigureUniqueIndexes(modelBuilder);
            ConfigureDefaultValues(modelBuilder);
        }

        private void ConfigureDefaultValues(ModelBuilder modelBuilder)
        {
        }

        // public override int SaveChanges()
        // {
        //     // var entities = ChangeTracker.Entries()
        //     //     .Where(x => x.Entity is KeyEntity && (x.State == EntityState.Added));
        //     // 
        //     // foreach (var entity in entities)
        //     //     ((KeyEntity)entity.Entity).Key = Guid.NewGuid().ToString();
        //     // 
        //     // return base.SaveChanges();
        // }

        private void ConfigureUniqueIndexes(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Order>()
            //     .HasIndex(x => x.Key);
        }
    }
}
