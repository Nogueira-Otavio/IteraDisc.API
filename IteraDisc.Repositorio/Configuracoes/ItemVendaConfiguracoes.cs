using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IteraDisc.Repositorio.Configuracoes
{
    public class ItemVendaConfiguracoes : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("ItemVenda").HasKey(iv => iv.ItemVendaId);

            builder.Property(nameof(ItemVenda.ItemVendaId)).HasColumnName("ItemVendaId");
            builder.Property(nameof(ItemVenda.ProdutoId)).HasColumnName("ProdutoId").IsRequired(true);
            builder.Property(nameof(ItemVenda.VendaId)).HasColumnName("VendaId").IsRequired(false);
            builder.Property(nameof(ItemVenda.Quantidade)).HasColumnName("Quantidade").IsRequired(true);
            builder.Property(nameof(ItemVenda.ValorItemVenda)).HasColumnName("ValorItemVenda").HasPrecision(18,2).IsRequired(true);
            builder.Property(nameof(ItemVenda.Vendido)).HasColumnName("Vendido").IsRequired(true);

            builder
                    .HasOne(itemVenda => itemVenda.Venda)
                    .WithMany(venda => venda.Itens)
                    .HasForeignKey(itemVenda => itemVenda.VendaId);

            builder
                    .HasOne(itemVenda => itemVenda.Produto)
                    .WithMany(produto => produto.Vendas)
                    .HasForeignKey(itemVenda => itemVenda.ProdutoId);
        }
    }
}