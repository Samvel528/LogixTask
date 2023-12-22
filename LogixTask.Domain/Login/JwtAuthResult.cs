using System.Text.Json.Serialization;

namespace LogixTask.Domain.Login;

public record JwtAuthResult
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }

    [JsonPropertyName("refreshToken")]
    public RefreshToken RefreshToken { get; set; }
}