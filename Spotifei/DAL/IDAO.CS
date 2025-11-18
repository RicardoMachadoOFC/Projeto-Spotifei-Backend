namespace Spotifei.DAO
{
    public interface IDAO<T>
    {
        void Cadastrar(T obj);
        void Atualizar(T obj);
        void Excluir(int id);
        List<T> ListarTodos();
        T? ListarPorId(int id); 
    }
}
