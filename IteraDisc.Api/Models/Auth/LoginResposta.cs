namespace IteraDisc.Api.Models.Auth
{
    public class LoginResposta
    {
        public string Token { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
    }
}