namespace Spotifei.Model;
public class Playlist
{

    public int PlaylistId { get; set; }


    public string Nome { get; set; }
    
    public int UsuarioId { get; set; }

    public Usuario Usuario { get; set; }
    public List<PlaylistMusica> PlaylistsMusicas { get; set; }
}