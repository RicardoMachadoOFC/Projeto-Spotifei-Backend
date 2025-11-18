public class UsuarioDAO : IDAO<Usuario>
{


    // espero que consigam usar o entity para testar isso, estou codando no escuro
    private readonly AppDbContext _context;

    public UsuarioDAO(AppDbContext context)
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

    public List<Usuario> ListarTodos()
    {
        return _context.Usuarios.ToList();
    }

    public Usuario ListarPorId(int id)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Id == id);
    }
}
