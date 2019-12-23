using FGO.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FGO.WebApi.Persistence.Context
{
    public class FGOContext : DbContext
    {

        public DbContext Instance => this;

        public virtual DbSet<ServantBaseModel> Servants { get; set; }

        protected FGOContext() { }
        public FGOContext(DbContextOptions<FGOContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("Database not properly configured");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FGOContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
