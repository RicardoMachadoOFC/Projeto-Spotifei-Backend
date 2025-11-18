namespace Spotifei.Model;
public class Artista
{
   
    public int ArtistaId { get; set; }

    public string Nome { get; set; } 
    

    public List<Album> Albuns { get; set; }
}