using Spotifei.Model;
using Microsoft.EntityFrameworkCore;

namespace Spotifei.DAO
{
    public class PlaylistDAO
    {
        private readonly SpotifeiContext _context;

        public PlaylistDAO(SpotifeiContext context)
        {
            _context = context;
        }

        public List<Playlist> ListarPorUsuario(int usuarioId)
        {
            return _context.Playlists
                .Include(p => p.PlaylistsMusicas)
                .Where(p => p.UsuarioId == usuarioId)
                .ToList();
        }

        public void Cadastrar(Playlist p)
        {
            _context.Playlists.Add(p);
            _context.SaveChanges();
        }

        public void Remover(int playlistId)
        {
            var p = _context.Playlists.Find(playlistId);
            if (p != null)
            {
                _context.Playlists.Remove(p);
                _context.SaveChanges();
            }
        }

        public void AdicionarMusica(int playlistId, int musicaId)
        {
            var pm = new PlaylistMusica { PlaylistId = playlistId, MusicaId = musicaId };
            _context.PlaylistsMusicas.Add(pm);
            _context.SaveChanges();
        }

        public void RemoverMusica(int playlistId, int musicaId)
        {
            var pm = _context.PlaylistsMusicas
                .FirstOrDefault(x => x.PlaylistId == playlistId && x.MusicaId == musicaId);
            if (pm != null)
            {
                _context.PlaylistsMusicas.Remove(pm);
                _context.SaveChanges();
            }
        }
    }
}
