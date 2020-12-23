﻿using Abp.EntityFrameworkCore;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Backend.EntityFrameworkCore
{
    public class BackendDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public DbSet<FJ> FJs { get; set; }
        public DbSet<FJ2> FJ2s { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RequestCompany> RequestCompanies { get; set; }
        public DbSet<Company> Companies { get; set; }

        public BackendDbContext(DbContextOptions<BackendDbContext> options)
            : base(options)
        {

        }
    }
}
