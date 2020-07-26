using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roteirizador.Domain.Models;

namespace Roteirizador.Data.Mappings
{
    public class UFMap : IEntityTypeConfiguration<UF>
    {
        public void Configure(EntityTypeBuilder<UF> builder)
        {
            builder.ToTable("ufs2");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Sigla).IsRequired();
            builder.Property(m => m.Nome).IsRequired();
        }
    }
}