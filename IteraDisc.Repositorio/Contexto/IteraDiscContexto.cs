using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IteraDisc.Dominio.Entidades;
using IteraDisc.Repositorio.Configuracoes;
using Microsoft.Extensions.Options;

namespace IteraDisc.Repositorio.Contexto
{
    public class IteraDiscContexto : DbContext
    {
        private readonly DbContextOptions _options;

        public DbSet<Usuario> Usuarios { get; set; }

        public IteraDiscContexto()
        {
            
        }

        public IteraDiscContexto(DbContextOptions options) : base(options)
        {
            _options = options;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                optionsBuilder.UseSqlServer(
                    "Server=localhost\\SQLEXPRESS01;Database=IteraDisc;Trusted_Connection=True;TrustServerCertificate=True"
                );
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsusarioConfiguracoes());
        }
    }
}