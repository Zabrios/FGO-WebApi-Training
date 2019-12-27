using FGO.WebApi.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FGO.WebApi.Persistence.Context.Configuration
{
    public class AscensionEntityConfiguration : IEntityTypeConfiguration<AscensionModel>
    {
        public void Configure(EntityTypeBuilder<AscensionModel> builder)
        {
            builder.HasOne(s => s.Servant)
                .WithMany(sbm => sbm.Ascensions)
                .HasForeignKey(s => s.ServantId);
        }
    }
}
