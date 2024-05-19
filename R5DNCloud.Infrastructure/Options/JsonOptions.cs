using System.Text.Encodings.Web;
using System.Text.Json;
using R5DNCloud.Infrastructure.Converters;

namespace R5DNCloud.Infrastructure.Options;

public static class JsonOptions
{
    private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        Converters =
        {
            new JsonLongConverter()
        }
    };

    public static JsonSerializerOptions Default
    {
        get
        {
            return _jsonSerializerOptions;
        }
    }
}