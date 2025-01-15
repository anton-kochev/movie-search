using Domain.Common;
using Domain.Entities;

namespace Application.Movies.Queries.GetMovies;

public record MovieDto(Guid Id, string Title, int ReleaseYear);

public static class MovieDtoExtensions
{
    public static IEnumerable<MovieDto> ToDto(this IEnumerable<Movie> entities)
    {
        return entities.Select(entity => entity.ToDto());
    }

    public static MovieDto ToDto(this Movie entity)
    {
        return new MovieDto(Guid.Parse(entity.Id), entity.Title, entity.ReleaseYear);
    }
}
