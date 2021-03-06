﻿namespace MasGlobal.Test.Infrastructure.Data.EntityFramework
{
    using MasGlobal.Test.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    public class DBContext : DbContext, IDisposable
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //var serviceProvider = ((IInfrastructure<IServiceProvider>)this).Instance;
                //var config = this.GetService<IConfigurationRoot>();

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


                // get the configuration from the app settings
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .Build();


                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDTO>()
                .ToTable("Employees");
        }

        public DbSet<EmployeeDTO> Employees { get; set; }
    }
}
