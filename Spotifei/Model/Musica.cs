namespace Spotifei.Model
{
    public class Musica
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int DuracaoSegundos { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; } = null!;

        public List<PlaylistMusica> PlaylistsMusicas { get; set; } = new();
    }
}
