using Spotifei.DAO;

namespace Spotifei.Controller
{
    public class LoginController
    {
        private readonly UsuarioDAO _dao;

        public LoginController(UsuarioDAO dao)
        {
            _dao = dao;
        }

        public bool Autenticar(string email, string senha)
        {
            return _dao.ListarTodos()
                       .Any(u => u.Email == email && u.Senha == senha);
        }
    }
}
