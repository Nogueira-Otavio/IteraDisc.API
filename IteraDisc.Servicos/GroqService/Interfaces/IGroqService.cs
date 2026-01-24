using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades.GroqService;

namespace IteraDisc.Servicos.GroqService.Interfaces
{
    public interface IGroqService
    {
        Task<string> EnviarAsync(string menssagemUsuario);
    }
}