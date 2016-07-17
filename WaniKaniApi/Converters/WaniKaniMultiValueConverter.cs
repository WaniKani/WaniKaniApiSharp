using System;
using System.Linq;
using Newtonsoft.Json;

namespace WaniKaniApi.Converters
{
    /// <summary>
    /// JSON converter used to read a string as an array using a split on the separator used by the WaniKani API.
    /// </summary>
    public class WaniKaniMultiValueConverter : JsonConverter
    {
        private const char Separator = ',';

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = reader.Value?.ToString();
            return value?.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
                .Select(v => v.Trim())
                .ToArray()
                ?? new string[] {};
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
