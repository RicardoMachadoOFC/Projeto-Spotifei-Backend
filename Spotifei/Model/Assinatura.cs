namespace Spotifei.Model
{
    public class Assinatura
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public string Plano { get; set; } = string.Empty;

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }
    }
}
