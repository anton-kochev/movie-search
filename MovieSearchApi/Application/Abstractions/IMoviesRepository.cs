using Domain.Common;
using Domain.Entities;

namespace Application.Abstractions;

public interface IMoviesRepository
{
    Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken);
    Task<IEnumerable<Movie>> GetMoviesAsync(MovieSearchCriteria search, CancellationToken cancellationToken);
}
