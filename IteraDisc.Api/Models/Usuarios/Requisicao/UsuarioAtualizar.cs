using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteraDisc.Api.Models.Usuarios.Requisicao
{
    public class UsuarioAtualizar
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}