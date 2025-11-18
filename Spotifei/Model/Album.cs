namespace Spotifei.Model
{
    public class Album
    {
        public int Id { get; set; }               
        public string Titulo { get; set; } = string.Empty;
        public int AnoLancamento { get; set; }
        public int ArtistaId { get; set; }
        public Artista? Artista { get; set; }     
        public List<Musica> Musicas { get; set; } = new List<Musica>();
    }
}
