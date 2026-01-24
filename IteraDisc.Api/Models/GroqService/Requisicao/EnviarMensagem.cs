using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades.GroqService;

namespace IteraDisc.Api.Models.GroqService.Requisicao
{
    public class EnviarMensagem
    {
        public List<Message> Messages { get; set; }
        public string Menssagem { get; set; }
    }
}