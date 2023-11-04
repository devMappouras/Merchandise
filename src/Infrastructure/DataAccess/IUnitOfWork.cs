using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.DataAccess;

public interface IUnitOfWork : IDisposable
{
    // Begin a database transaction
    void BeginTransaction();

    // Commit the transaction
    void Commit();

    // Rollback the transaction
    void Rollback();

    // Save pending changes to the database
    void SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken); // Asynchronous SaveChanges method
}