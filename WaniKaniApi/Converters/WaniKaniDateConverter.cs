using System;
using Newtonsoft.Json;

namespace WaniKaniApi.Converters
{
    /// <summary>
    /// JSON converter that reads a date from a unix-style date (seconds elapsed starting from 1970-01-01 00:00:00).
    /// </summary>
    public class WaniKaniDateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string stringValue = reader.Value?.ToString() ?? string.Empty;
            long value;
            
            if (long.TryParse(stringValue, out value))
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value);

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
