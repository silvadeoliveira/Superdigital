using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Superdigital.Domain.Entities.AggregateCliente;

namespace Superdigital.Data.Mappings
{
    public class ContaMapping : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.HasKey(c => c.Id);


            builder.HasOne(x => x.TitutalarConta)
                .WithMany(x => x.ContaCorrente)
                .HasForeignKey(x => x.TitularId);

            builder.ToTable("Enderecos");
        }
    }
}