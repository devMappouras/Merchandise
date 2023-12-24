

using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class Extensions
{
    public static async Task<IEnumerable<TSource>> ToIEnumerableAsync<TSource>(
    this IQueryable<TSource> source,
    CancellationToken cancellationToken = default)
    {
        var list = new List<TSource>();
        await foreach (var element in source.AsAsyncEnumerable().WithCancellation(cancellationToken))
        {
            list.Add(element);
        }

        return list;
    }
}
