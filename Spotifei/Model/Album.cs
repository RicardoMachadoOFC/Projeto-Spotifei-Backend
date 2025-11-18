namespace Spotifei.Model;
public class Album
{
    public int id { get; set; }
    public string Titulo { get; set; } 
    public int AnoLancamento { get; set; }
    public int ArtistaId { get; set; }
    public Artista Artista { get; set; }
    public List<Musica> Musicas { get; set; }
}