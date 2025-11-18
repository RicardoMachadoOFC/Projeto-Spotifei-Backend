namespace Spotifei.Model;
    public class Usuario
    {
          public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public List<Historico> Historicos { get; set; }
        public List<Assinatura> Assinaturas { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
