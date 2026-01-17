using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IteraDisc.Repositorio.Configuracoes
{
    public class UsusarioConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario").HasKey(u => u.UsuarioId);

            builder.Property(nameof(Usuario.UsuarioId)).HasColumnName("UsuarioId");
            builder.Property(nameof(Usuario.Nome)).HasColumnName("Nome").IsRequired(true);
            builder.Property(nameof(Usuario.Email)).HasColumnName("Email").IsRequired(true);
            builder.Property(nameof(Usuario.Senha)).HasColumnName("Senha").IsRequired(true);
            builder.Property(nameof(Usuario.Ativo)).HasColumnName("Ativo");
        }
    }
}