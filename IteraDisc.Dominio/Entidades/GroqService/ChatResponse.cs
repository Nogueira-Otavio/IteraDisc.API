using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteraDisc.Dominio.Entidades.GroqService
{
    public class ChatResponse
    {
        public string Id { get; set; }
        public List<Choice> Choices { get; set; }
    }

    public class Choice
    {
        public Message Message { get; set; }
    }
}