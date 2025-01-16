using Domain.Entities;

namespace Application.Movies.Queries.GetMovies;

public record MovieDto(Guid Id, string Title, int ReleaseYear, string Poster);

public static class MovieDtoExtensions
{
    public static IEnumerable<MovieDto> ToDto(this IEnumerable<Movie> entities)
    {
        return entities.Select(entity => entity.ToDto());
    }

    private static MovieDto ToDto(this Movie entity)
    {
        return new MovieDto(Guid.Parse(entity.Id), entity.Title, entity.ReleaseYear, entity.Poster);
    }
}
