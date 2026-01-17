using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteraDisc.Api.Models.Usuarios.Resposta
{
    public class UsuarioResponse
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}