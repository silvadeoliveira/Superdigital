using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Superdigital.Domain.Entities.AggregatePessoa;

namespace Superdigital.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomePessoa)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.DtNascimento)
                .HasColumnName("DtNascimento")
                .HasColumnType("Datetime");

            builder.Property(p => p.NomeMae)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.NomePai)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.NomeSocial)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.OwnsOne(p => p.Cpf, cm =>
            {
                cm.Property(c => c.Numero)
                    .IsRequired()
                    .HasColumnName("Cpf")
                    .HasColumnType("int");
            });

            builder.OwnsOne(p => p.Email, cm =>
            {
                cm.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("varchar(100)");

            });



            builder.Property(p => p.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("Datetime");

            builder.Property(p => p.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("bit");

            builder.HasMany(e => e.Enderecos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId);

            builder.ToTable("Clientes");
        }
    }
}