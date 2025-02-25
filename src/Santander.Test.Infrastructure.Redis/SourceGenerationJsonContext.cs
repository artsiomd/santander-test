using Santander.Test.Domain;
using System.Text.Json.Serialization;

namespace Santander.Test.Infrastructure.Redis;

[JsonSerializable(typeof(Story))]
[JsonSerializable(typeof(List<Story>))]
internal partial class SourceGenerationJsonContext : JsonSerializerContext
{
}
