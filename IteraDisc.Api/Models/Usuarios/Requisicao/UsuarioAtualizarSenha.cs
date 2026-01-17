using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteraDisc.Api.Models.Usuarios.Requisicao
{
    public class UsuarioAtualizarSenha
    {
        public int UsuarioId { get; set; }
        public string Senha { get; set; }
        public string SenhaAntiga { get; set; }
    }
}