using Abp.EntityFrameworkCore;
using Abp.JT.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.JTCore.EntityFrameworkCore.EntityFramework
{
    public abstract class AbpJTCommonDbContext<TSelf> : AbpDbContext
         where TSelf : AbpJTCommonDbContext<TSelf>
    {
        public virtual DbSet<Setting> Settings { get; set; }

        protected AbpJTCommonDbContext(DbContextOptions<TSelf> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setting>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.Name, e.UserId }).IsUnique().HasFilter(null);
            });
        }
    }
}
