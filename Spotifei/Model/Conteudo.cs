namespace Spotifei.Model;
public class Conteudo
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Artista { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty; // musica / podcast

        public string Url { get; set; } = string.Empty;

        public List<Historico> Historicos { get; set; }
    }