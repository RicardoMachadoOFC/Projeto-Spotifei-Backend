namespace Spotifei.Model
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string Titulo { get; set; } = string.Empty;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public List<PlaylistMusica> PlaylistsMusicas { get; set; } = new();
    }
}
