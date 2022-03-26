namespace CidadeInteligente.Dominio.Interfaces
{
    public interface IBase<T> where T : class
    {
        void Adicionar(T obj);

        void Atualizar(T obj);

        void Excluir(T obj);

        IList<T> Listar();

    }
}
