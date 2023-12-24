using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly MerchantiseDBContext _context;
    private DbSet<T> _set;

    public BaseRepository(MerchantiseDBContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await _set.FindAsync(id);
        if (entity == null)
        {
            return null!;
        }

        _context.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    //public override async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
    //{
    //    var entity = await _set.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
    //    _context.Entry(entity).State = EntityState.Detached;
    //    return entity;
    //}

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return _set.AsNoTracking().ToIEnumerableAsync();
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}