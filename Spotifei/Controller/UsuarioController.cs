using Spotifei.DAO;
using Spotifei.Model;

namespace Spotifei.Controller
{
    public class UsuarioController
    {
        private readonly UsuarioDAO _dao;

        public UsuarioController(UsuarioDAO dao)
        {
            _dao = dao;
        }

        public void Cadastrar(Usuario u) => _dao.Cadastrar(u);

        public List<Usuario> Listar() => _dao.ListarTodos();

        public Usuario Buscar(int id) => _dao.ListarPorId(id);

        public void Atualizar(Usuario u) => _dao.Atualizar(u);

        public void Excluir(int id) => _dao.Excluir(id);
    }
}
