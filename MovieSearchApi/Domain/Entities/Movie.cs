using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities;

public sealed class Movie
{
    [JsonPropertyName("id")] public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Title { get; init; } = string.Empty;
    public Year ReleaseYear { get; init; }
    public string Poster { get; init; } = string.Empty;
}
