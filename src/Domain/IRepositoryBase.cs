
public interface IRepositoryBase<T>
{
    Task<T> GetByIdAsync(int id);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
}