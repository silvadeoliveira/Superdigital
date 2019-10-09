using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Superdigital.Domain.Entities.AggregateCliente;

namespace Superdigital.Data.Mappings
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TipoTransacaoId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.StatusTrasferenciaId)
                .IsRequired()
                .HasColumnType("int");
            

            builder.ToTable("TransferenciasBancarias");
        }
    }
}