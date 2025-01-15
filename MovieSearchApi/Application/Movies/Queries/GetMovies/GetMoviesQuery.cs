using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Movies.Queries.GetMovies;

public record GetMoviesQuery : IRequest<IEnumerable<MovieDto>>
{
}

public sealed class GetMoviesHandler(IMoviesRepository moviesRepository)
    : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
{
    public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Movie> entities = await moviesRepository.GetMoviesAsync(cancellationToken);

        return entities.ToDto();
    }
}
