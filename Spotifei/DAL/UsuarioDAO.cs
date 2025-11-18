using Spotifei.Model;

namespace Spotifei.DAO
{
    public class UsuarioDAO : IDAO<Usuario>
    {
        private readonly SpotifeiContext _context;

        public UsuarioDAO(SpotifeiContext context)
        {
            _context = context;
        }

        public void Cadastrar(Usuario u)
        {
            _context.Usuarios.Add(u);
            _context.SaveChanges();
        }

        public void Atualizar(Usuario u)
        {
            _context.Usuarios.Update(u);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var usuario = ListarPorId(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public List<Usuario> ListarTodos() => _context.Usuarios.ToList();

        public Usuario? ListarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }
    }
}
