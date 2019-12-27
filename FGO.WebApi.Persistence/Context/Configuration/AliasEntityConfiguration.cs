using FGO.WebApi.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FGO.WebApi.Persistence.Context.Configuration
{
    public class AliasEntityConfiguration : IEntityTypeConfiguration<AliasModel>
    {
        public void Configure(EntityTypeBuilder<AliasModel> builder)
        {
            builder.HasOne(a => a.Servant)
                .WithMany(s => s.Aliases)
                .HasForeignKey(a => a.ServantId);
        }
    }
}
