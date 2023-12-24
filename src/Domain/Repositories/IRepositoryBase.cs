﻿
public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
}