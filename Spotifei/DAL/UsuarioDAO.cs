public class UsuarioDAO : IDAO<Usuario>
{

    // -ricardo,
    // dados dos usuarios
    private static List<Usuario> _usuarios = new();

    public void Cadastrar(Usuario u) => _usuarios.Add(u);

    public void Atualizar(Usuario u)
    {
        var existente = ListarPorId(u.Id);
        if (existente == null) return;

        existente.Nome = u.Nome;
        existente.Email = u.Email;
        existente.Senha = u.Senha;
    }

    public void Excluir(int id)
    {
        var u = ListarPorId(id);
        if (u != null) _usuarios.Remove(u);
    }

    public List<Usuario> ListarTodos() => _usuarios;

    public Usuario ListarPorId(int id) => _usuarios.FirstOrDefault(x => x.Id == id);
}
