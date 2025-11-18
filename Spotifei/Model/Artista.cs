namespace Spotifei.Model
{
    public class Artista
    {
        public int ArtistaId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public List<Album> Albuns { get; set; } = new List<Album>();
    }
}
