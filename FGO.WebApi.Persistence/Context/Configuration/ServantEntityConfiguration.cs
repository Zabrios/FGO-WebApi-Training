using FGO.WebApi.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace FGO.WebApi.Persistence.Context.Configuration
{
    public class ServantEntityConfiguration : IEntityTypeConfiguration<ServantBaseModel>
    {
        public void Configure(EntityTypeBuilder<ServantBaseModel> builder)
        {
            builder.Property(e => e.ID)
                .ValueGeneratedNever()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);
        }
    }
}
