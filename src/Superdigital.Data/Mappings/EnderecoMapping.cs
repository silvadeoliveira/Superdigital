using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Superdigital.Domain.Entities.AggregatePessoa;

namespace Superdigital.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Enderecos>
    {
        public void Configure(EntityTypeBuilder<Enderecos> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ClienteId)
                .HasColumnName("ClienteId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Endereco)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Complemento)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.OwnsOne(e => e.Estado, cm =>
            {
                cm.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasColumnType("varchar(2)");
            });

            builder.OwnsOne(e => e.Cep, cm =>
            {
                cm.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("Cep")
                    .HasColumnType("varchar(10)");
            });

            builder.Property(e => e.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("Datetime");

            builder.Property(e => e.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("bit");

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.ClienteId);

            builder.ToTable("Enderecos");
        }
    }
}
