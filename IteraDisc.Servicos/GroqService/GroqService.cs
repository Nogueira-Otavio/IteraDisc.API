using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades.GroqService;
using IteraDisc.Servicos.GroqService.Interfaces;
using IteraDisc.Servicos.GroqService.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace IteraDisc.Servicos.GroqService
{
    public class GroqService : IGroqService
    {
        private readonly HttpClient _httpClient;
        private const string Endpoint = "https://api.groq.com/openai/v1/chat/completions";

        private const string SystemPrompt = @"
Você é um atendente virtual especializado em uma loja de discos de vinil e CDs.
Responda apenas perguntas relacionadas a:
- Música
- Discos
- Vinil
- CDs
- Artistas, bandas e álbuns
- Estilos musicais
- Recomendações musicais
- Funcionamento de uma loja de discos

Fale de forma amigável, educada e como um vendedor apaixonado por música.
Se a pergunta não tiver relação com música ou discos, responda educadamente que só pode ajudar nesses assuntos.
Nunca saia desse papel.
";

        public GroqService(HttpClient httpClient, IOptions<GroqSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", settings.Value.ApiKey);
        }

        public async Task<string> EnviarAsync(string menssagemUsuario)
        {
            var messages = new List<Message>
            {
                new Message { Role = "system", Content = SystemPrompt },
                new Message { Role = "user", Content = menssagemUsuario }
            };
            
            var request = new ChatRequest
            {
                model = "groq/compound",
                messages = messages,
                temperature = 0.7,
                max_tokens = 512
            };

            var response = await _httpClient.PostAsJsonAsync(Endpoint, request);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            var responseString = await response.Content.ReadAsStringAsync();
            var chatResponse = JsonConvert.DeserializeObject<ChatResponse>(responseString);

            return chatResponse.Choices[0].Message.Content;
        }
    }
}
