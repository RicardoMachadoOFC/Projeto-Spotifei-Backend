public class LoginController
{
    private readonly UsuarioDAO _dao;

    public LoginController(UsuarioDAO dao)
    {
        _dao = dao;
    }

    public bool Autenticar(string email, string senha)
    {
        var usuarios = _dao.ListarTodos();

        return usuarios.Any(u => u.Email == email && u.Senha == senha);
    }
}
