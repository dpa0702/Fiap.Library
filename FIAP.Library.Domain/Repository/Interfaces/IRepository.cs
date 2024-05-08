namespace FIAP.Library.Domain.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAll(CancellationToken ct);
        Task<T> GetById(int id, CancellationToken ct);
        Task Insert(T entity, CancellationToken ct);
        Task Update(T entity, CancellationToken ct);
    }
}
