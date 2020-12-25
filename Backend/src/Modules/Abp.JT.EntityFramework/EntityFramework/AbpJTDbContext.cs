using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.JTCore.EntityFrameworkCore.EntityFramework
{
    public abstract class AbpJTDbContext<TSelf> : AbpJTCommonDbContext<TSelf>
         where TSelf : AbpJTCommonDbContext<TSelf>
    {
        protected AbpJTDbContext(DbContextOptions<TSelf> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
