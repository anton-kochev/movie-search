using Domain.Entities;

namespace Application.Abstractions;

public interface IMoviesRepository
{
    Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken);
}
