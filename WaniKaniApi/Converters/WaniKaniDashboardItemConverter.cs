using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WaniKaniApi.Models;
using System.Reflection;

namespace WaniKaniApi.Converters
{
    /// <summary>
    /// JSON converter that helps picking the right DashboardItem type.
    /// </summary>
    public class WaniKaniDashboardItemConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Type targetType = objectType.GenericTypeArguments.FirstOrDefault();
            if (targetType == null)
                throw new Exception("The WaniKaniDashboardItem container should expect a generic typed list.");

            JArray array = JArray.Load(reader);
            var results = array.Children().Where(c => c.Type == JTokenType.Object).Select(o => Read((JObject)o));

            if (targetType == typeof(WaniKaniCriticalItem))
                return results.OfType<WaniKaniCriticalItem>().ToList();
            if (targetType == typeof(WaniKaniRecentUnlock))
                return results.OfType<WaniKaniRecentUnlock>().ToList();

            return results.ToList();
        }

        private static object Read(JObject item)
        {
            if (item["percentage"] != null)
            {
                var result = item.ToObject<WaniKaniCriticalItem>();
                result.Item = GetItem(item);
                return result;
            }
            if (item["unlocked_date"] != null)
            {
                var result = item.ToObject<WaniKaniRecentUnlock>();
                result.Item = GetItem(item);
                return result;
            }

            return null;
        }

        private static WaniKaniDashboardItem GetItem(JObject item)
        {
            string typeValue = item["type"].Value<string>();
            switch (typeValue)
            {
                case "vocabulary":
                    return item.ToObject<WaniKaniDashboardVocabulary>();
                case "kanji":
                    return item.ToObject<WaniKaniDashboardKanji>();
                case "radical":
                    return item.ToObject<WaniKaniDashboardRadical>();
                default:
                    return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(WaniKaniCriticalItem).GetTypeInfo().IsAssignableFrom(objectType)
                || typeof(WaniKaniDashboardItem).GetTypeInfo().IsAssignableFrom(objectType);
        }
    }
}
