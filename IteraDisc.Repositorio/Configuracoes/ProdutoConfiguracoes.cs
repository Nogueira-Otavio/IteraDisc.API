using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IteraDisc.Repositorio.Configuracoes
{
    public class ProdutoConfiguracoes : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto").HasAlternateKey(p => p.ProdutoId);

            builder.Property(nameof(Produto.ProdutoId)).HasColumnName("ProdutoId");
            builder.Property(nameof(Produto.Nome)).HasColumnName("Nome").IsRequired(true);
            builder.Property(nameof(Produto.Descricao)).HasColumnName("Descricao").IsRequired(true);
            builder.Property(nameof(Produto.Ativo)).HasColumnName("Ativo").IsRequired(true);
        }
    }
}