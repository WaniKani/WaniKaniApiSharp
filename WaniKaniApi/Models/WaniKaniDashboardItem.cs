using Newtonsoft.Json;
using WaniKaniApi.Converters;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Base class for items as formed by the recent unlocks and critical items list requests.
    /// See <see cref="WaniKaniApi.Models.WaniKaniItem"/> for the more complete type of item.
    /// </summary>
    public abstract class WaniKaniDashboardItem
    {
        /// <summary>
        /// Gets or sets the kanji, character or kanji reading of the item.
        /// </summary>
        [JsonProperty(PropertyName = "character")]
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets the meanings of the item.
        /// </summary>
        [JsonProperty(PropertyName = "meaning")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] Meanings { get; set; }

        /// <summary>
        /// Gets or sets the WaniKani level of the item.
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }
    }
}
