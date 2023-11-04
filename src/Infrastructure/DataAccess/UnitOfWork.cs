using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction _transaction;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        try
        {
            _context.SaveChanges();
            _transaction?.Commit();
        }
        catch
        {
            Rollback();
            throw;
        }
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
