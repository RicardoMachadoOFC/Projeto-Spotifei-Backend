using Spotifei.Model;
using Microsoft.EntityFrameworkCore;

namespace Spotifei.Service
{
    public class PlaylistService
    {
        private readonly SpotifeiContext _context;

        public PlaylistService(SpotifeiContext context)
        {
            _context = context;
        }

        public Playlist CriarPlaylist(int usuarioId, string titulo)
        {
            var playlist = new Playlist
            {
                Titulo = titulo,
                UsuarioId = usuarioId
            };

            _context.Playlists.Add(playlist);
            _context.SaveChanges();

            return playlist;
        }

        public List<Playlist> ListarPlaylists(int usuarioId)
        {
            return _context.Playlists
                .Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.PlaylistsMusicas)
                .ThenInclude(pm => pm.Musica)
                .ToList();
        }

        public void AdicionarMusica(int playlistId, int musicaId)
        {
            var existente = _context.PlaylistsMusicas
                .FirstOrDefault(pm => pm.PlaylistId == playlistId && pm.MusicaId == musicaId);

            if (existente != null) return;

            var pm = new PlaylistMusica
            {
                PlaylistId = playlistId,
                MusicaId = musicaId
            };

            _context.PlaylistsMusicas.Add(pm);
            _context.SaveChanges();
        }

        public void RemoverPlaylist(int playlistId)
        {
            var playlist = _context.Playlists.Find(playlistId);
            if (playlist == null) return;

            _context.Playlists.Remove(playlist);
            _context.SaveChanges();
        }

        public void RemoverMusica(int playlistId, int musicaId)
        {
            var pm = _context.PlaylistsMusicas
                .FirstOrDefault(x => x.PlaylistId == playlistId && x.MusicaId == musicaId);

            if (pm == null) return;

            _context.PlaylistsMusicas.Remove(pm);
            _context.SaveChanges();
        }
    }
}
