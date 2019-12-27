using FGO.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using FGO.WebApi.Persistence.Contracts;
using System.Configuration;
using System.Linq;
using FGO.WebApi.Domain.Entities.Models;

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
            //optionsBuilder.UseSqlServer(Configuration["ConnectionString"]);
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("Database not properly configured");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FGOContext).Assembly);

            //modelBuilder.Entity<ServantBaseModel>()
            //    .Property(e => e.ID)
            //    .ValueGeneratedNever()
            //    .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

            //modelBuilder.Entity<AscensionModel>()
            //    .HasOne<ServantBaseModel>(s => s.Servant)
            //    .WithMany(sbm => sbm.Ascensions)
            //    .HasForeignKey(s => s.ServantId);

            //modelBuilder.Entity<AliasModel>()
            //    .HasOne(a => a.Servant)
            //    .WithMany(s => s.Aliases)
            //    .HasForeignKey(a => a.ServantId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
