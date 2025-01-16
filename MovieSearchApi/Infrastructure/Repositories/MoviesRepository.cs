using Application.Abstractions;
using Domain.Common;
using Domain.Entities;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Repositories;

public sealed class MoviesRepository(CosmosClient client) : Repository<Movie>(client), IMoviesRepository
{
    public async Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken)
    {
        return (await GetItemsAsync(cancellationToken)).ToList();
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync(MovieSearchCriteria search,
        CancellationToken cancellationToken)
    {
        return (await GetItemsAsync(cancellationToken))
            .Where(t => t.Title.Contains(search.Title, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    protected override string ContainerName()
    {
        return "Movies";
    }
}
