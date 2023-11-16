using System.Text.Json.Serialization;

namespace Data.Models;

public class Webhook
{
    [JsonPropertyName("event")]
    public string Event { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}
