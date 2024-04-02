using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Identity;

namespace Adapter.Identity;

public class ProblemErrorConverter : JsonConverter<ProblemError>
{
    public override ProblemError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Ensure we're reading a JSON object
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException($"Unexpected token type: {reader.TokenType}");
        }

        var problemError = new ProblemError();
        var errorProperty = string.Empty;
        List<string> errorArray = [];
        List<string> outerErrorArray = [];

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                errorProperty = reader.GetString() ?? string.Empty;
            }

            if (reader.TokenType == JsonTokenType.EndArray)
            {
                outerErrorArray.Add($"{errorProperty} : {string.Join(", ", errorArray)}");
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                errorArray.Add(reader.GetString() ?? string.Empty);
            }

            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }
        }

        problemError.Errors = outerErrorArray;
        return problemError;
    }

    public override void Write(Utf8JsonWriter writer, ProblemError value, JsonSerializerOptions options)
    {
        // This converter doesn't have to support serialization
        throw new NotImplementedException();
    }
}
