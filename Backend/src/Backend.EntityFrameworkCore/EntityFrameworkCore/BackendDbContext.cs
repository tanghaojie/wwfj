using Abp.EntityFrameworkCore;
using Abp.JTCore.EntityFrameworkCore.EntityFramework;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Backend.EntityFrameworkCore
{
    public class BackendDbContext : AbpJTDbContext<BackendDbContext>
    {
        //Add DbSet properties for your entities...

        public DbSet<FJ> FJs { get; set; }
        public DbSet<FJ2> FJ2s { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RequestCompany> RequestCompanies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Option> Options { get; set; }

        public BackendDbContext(DbContextOptions<BackendDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Option>(b =>
            {
                b.HasIndex(e => e.OptionType).IsUnique().HasFilter(null);
            });
        }
    }
}
