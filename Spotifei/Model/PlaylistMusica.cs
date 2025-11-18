namespace Spotifei.Model;
public class PlaylistMusica
{
    public int PlaylistId { get; set; }
    public int MusicaId { get; set; }


    public Playlist Playlist { get; set; }
    public Musica Musica { get; set; }
   
}