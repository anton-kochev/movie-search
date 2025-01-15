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
                Poster = "https://m.media-amazon.com/images/M/MV5BMDAyY2FhYjctNDc5OS00MDNlLThiMGUtY2UxYWVkNGY2ZjljXkEyXkFqcGc@._V1_FMjpg_UX1200_.jpg",
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "The Godfather",
                ReleaseYear = 1972,
                Poster = "https://m.media-amazon.com/images/M/MV5BYTJkNGQyZDgtZDQ0NC00MDM0LWEzZWQtYzUzZDEwMDljZWNjXkEyXkFqcGc@._V1_FMjpg_UY1982_.jpg",
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "The Dark Knight",
                ReleaseYear = 2008,
                Poster = ""
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Thing",
                ReleaseYear = 1982,
                Poster = "https://m.media-amazon.com/images/M/MV5BYTA3NDU5MWEtNTk4Yy00ZDNkLThmZTQtMjU3ZGVhYzAyMzU4XkEyXkFqcGc@._V1_FMjpg_UX800_.jpg",
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
