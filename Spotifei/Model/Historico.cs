using Spotifei.Model;
namespace Spotifei.Model{

    public class Historico
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int ConteudoId { get; set; }
        public Conteudo Conteudo { get; set; }

        public DateTime DataReproducao { get; set; }
    }
}