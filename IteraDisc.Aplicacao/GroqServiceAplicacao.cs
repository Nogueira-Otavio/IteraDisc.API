using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.Entidades.GroqService;
using IteraDisc.Servicos.GroqService;
using IteraDisc.Servicos.GroqService.Interfaces;

namespace IteraDisc.Aplicacao
{
    public class GroqServiceAplicacao : IGroqServiceAplicacao
    {
        private readonly IGroqService _groqService;

        public GroqServiceAplicacao(IGroqService groqService)
        {
            _groqService = groqService;
        }

        public async Task<string> EnviarAsync(string menssagem)
        {
            return await _groqService.EnviarAsync(menssagem);
        }
    }
}