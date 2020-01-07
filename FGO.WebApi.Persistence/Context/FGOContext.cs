using FGO.WebApi.Domain.Entities.Models;
using FGO.WebApi.Persistence.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;

namespace FGO.WebApi.Persistence.Context
{
    public class FGOContext : DbContext, IFGOContext
    {
        public DbContext Instance => this;

        public virtual DbSet<ServantBaseModel> Servants { get; set; }
        public virtual DbSet<AscensionModel> Ascensions { get; set; }
        public virtual DbSet<AliasModel> Aliases { get; set; }

        protected FGOContext() 
        {
        }
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
