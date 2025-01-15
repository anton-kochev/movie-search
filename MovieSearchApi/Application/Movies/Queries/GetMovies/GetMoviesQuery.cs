using Application.Abstractions;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Movies.Queries.GetMovies;

public record GetMoviesQuery(string SearchTitle) : IRequest<IEnumerable<MovieDto>>
{
}

public sealed class GetMoviesHandler(IMoviesRepository moviesRepository)
    : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
{
    public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        MovieSearchCriteria search = new(request.SearchTitle);

        IEnumerable<Movie> entities = string.IsNullOrWhiteSpace(request.SearchTitle)
            ? await moviesRepository.GetMoviesAsync(cancellationToken)
            : await moviesRepository.GetMoviesAsync(search, cancellationToken);

        return entities.ToDto();
    }
}
