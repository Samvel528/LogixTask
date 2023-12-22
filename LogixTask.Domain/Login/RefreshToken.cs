using System.Text.Json.Serialization;

namespace LogixTask.Domain.Login;

public record RefreshToken
{
    [JsonPropertyName("username")]
    public string UserName { get; set; }

    [JsonPropertyName("tokenString")]
    public string TokenString { get; set; }

    [JsonPropertyName("expireAt")]
    public DateTime ExpireAt { get; set; }
}