namespace Spotifei.Model
{
    public class PlaylistMusica
    {
        public int PlaylistId { get; set; }
        public int MusicaId { get; set; }

        // EF vai popular essas propriedades, então usamos null-forgiving
        public Playlist Playlist { get; set; } = null!;
        public Musica Musica { get; set; } = null!;
    }
}
