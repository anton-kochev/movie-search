using Application.Abstractions;
using Domain.Common;
using Domain.Entities;

namespace Infrastructure.Repositories;

public sealed class MoviesRepository : IMoviesRepository
{
    public async Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken)
    {
        return await Task.FromResult(new List<Movie>
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "The Shawshank Redemption",
                ReleaseYear = 1994,
                Poster = ""
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "The Godfather",
                ReleaseYear = 1972,
                Poster = ""
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "The Dark Knight",
                ReleaseYear = 2008,
                Poster = ""
            }
        });
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync(MovieSearchCriteria search,
        CancellationToken cancellationToken)
    {
        return (await GetMoviesAsync(cancellationToken)).Where(movie =>
            movie.Title.Contains(search.Title, StringComparison.OrdinalIgnoreCase));
    }
}
