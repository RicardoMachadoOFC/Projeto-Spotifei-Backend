public class UsuarioController
{
    private UsuarioDAO dao = new UsuarioDAO();

    public void CadastrarUsuario(Usuario u) => dao.Cadastrar(u);

    public List<Usuario> ListarUsuarios() => dao.ListarTodos();

    public Usuario BuscarPorId(int id) => dao.ListarPorId(id);

    public void Atualizar(Usuario u) => dao.Atualizar(u);

    public void Excluir(int id) => dao.Excluir(id);
}
