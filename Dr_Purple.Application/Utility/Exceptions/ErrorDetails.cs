using System.Text.Json;

namespace Dr_Purple.Application.Utility.Exceptions;
public class ErrorDetails
{
    public string? Message { get; set; }
    public int? StatusCode { get; set; }
    public string? MessageId { get; set; }
    public override string ToString()
    => JsonSerializer.Serialize(this, new JsonSerializerOptions()
    {
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
}
