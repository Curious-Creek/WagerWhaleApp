using System.Text.Json;

namespace Adapter.Identity;

public static class IdentityJsonSerializerOptions
{
    public static JsonSerializerOptions Options => new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new ProblemErrorConverter() }
    };
}