using Spotifei.DAO;
using Spotifei.Model;

namespace Spotifei.Controller
{
    public class PlaylistController
    {
        private readonly PlaylistDAO _dao;

        public PlaylistController(PlaylistDAO dao)
        {
            _dao = dao;
        }

        public List<Playlist> Listar(int usuarioId)
        {
            return _dao.ListarPorUsuario(usuarioId);
        }

        public void Cadastrar(Playlist p)
        {
            _dao.Cadastrar(p);
        }

        public void Remover(int playlistId)
        {
            _dao.Remover(playlistId);
        }

        public void AdicionarMusica(int playlistId, int musicaId)
        {
            _dao.AdicionarMusica(playlistId, musicaId);
        }

        public void RemoverMusica(int playlistId, int musicaId)
        {
            _dao.RemoverMusica(playlistId, musicaId);
        }
    }
}
