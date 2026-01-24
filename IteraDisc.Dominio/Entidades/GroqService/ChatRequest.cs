using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteraDisc.Dominio.Entidades.GroqService
{
    public class ChatRequest
    {
        public string model { get; set; } = "gemma2-9b-it";
        public List<Message> messages { get; set; }
        public double temperature { get; set; }
        public int max_tokens { get; set; }
    }
}