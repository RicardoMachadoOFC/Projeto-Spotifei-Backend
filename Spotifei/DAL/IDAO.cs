interface IDAO<T>
{
    void Cadastrar(T objeto);
    void Atualizar(T objeto);
    void Excluir(int id);
    List<T> ListarTodos();
    T ListarPorId(int id);
}
