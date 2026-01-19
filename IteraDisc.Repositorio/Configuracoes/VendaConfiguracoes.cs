using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IteraDisc.Repositorio.Configuracoes
{
    public class VendaConfiguracoes : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda").HasKey(venda => venda.VendaId);

            builder.Property(nameof(Venda.VendaId)).HasColumnName("VendaId");
            builder.Property(nameof(Venda.UsuarioId)).HasColumnName("UsuarioId").IsRequired(true);
            builder.Property(nameof(Venda.DataVenda)).HasColumnName("DataVenda").IsRequired(true);
            builder.Property(nameof(Venda.ValorTotalVenda)).HasColumnName("ValorTotalVenda").HasPrecision(18,2).IsRequired(true);

            builder
                    .HasOne(venda => venda.Usuario)
                    .WithMany(usuario => usuario.Vendas)
                    .HasForeignKey(venda => venda.UsuarioId);
        }
    }
}