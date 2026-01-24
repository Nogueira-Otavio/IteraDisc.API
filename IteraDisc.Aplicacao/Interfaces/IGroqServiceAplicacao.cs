using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades.GroqService;

namespace IteraDisc.Aplicacao.Interfaces
{
    public interface IGroqServiceAplicacao
    {
         Task<string> EnviarAsync(string menssagem);
    }
}