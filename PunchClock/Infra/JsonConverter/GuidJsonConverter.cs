using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PunchClock.Infra.JsonConverter
{
    public class GuidJsonConverter : JsonConverter<Guid>
    {
        public GuidJsonConverter()
        {
        }

        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetGuid(out Guid value))
            {
                return value;
            } 
            else
            {
                return Guid.Empty;
            }
        }

        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}