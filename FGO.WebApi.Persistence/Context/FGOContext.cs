using FGO.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;

namespace FGO.WebApi.Persistence.Context
{
    public class FGOContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public DbContext Instance => this;

        public virtual DbSet<ServantBaseModel> Servants { get; set; }

        protected FGOContext(IConfiguration config) 
        {
            Configuration = config;
        }
        public FGOContext(DbContextOptions<FGOContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Configuration["ConnectionString"]);
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("Database not properly configured");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FGOContext).Assembly);
            modelBuilder.Entity<ServantBaseModel>()
                .Property(e => e.Alias)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<ServantBaseModel>()
                .Property(e => e.ID)
                .ValueGeneratedNever()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);


            base.OnModelCreating(modelBuilder);
        }

    }
}
