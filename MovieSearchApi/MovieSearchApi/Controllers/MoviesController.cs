using Application.Movies.Queries.GetMovies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieSearchApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController(IMediator mediator, ILogger<MoviesController> logger) : ControllerBase
{
    /// <summary>
    ///     Get all movies are meeting the search criteria provided in query string.
    ///     The search criteria are optional. The search criteria are:
    ///     api/movies?s=[movie title]&apikey=[apikey]
    /// </summary>
    /// <param name="s">The search criteria for movie title.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet(Name = "GetMovies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies([FromQuery] string? s,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("GetMovies for {s}", s);

        IEnumerable<MovieDto> movies = await mediator.Send(new GetMoviesQuery(s ?? string.Empty), cancellationToken);

        return Ok(movies);
    }
}
