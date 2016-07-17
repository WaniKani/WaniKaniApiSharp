using Newtonsoft.Json;
using WaniKaniApi.Converters;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Base for items with complete user information, as returned by the radicals/kanji/vocabulary list requests.
    /// </summary>
    public abstract class WaniKaniItem
    {
        /// <summary>
        /// Gets or sets the main representation of the item (kanji reading for vocabulary; character for kanji and radicals).
        /// Can be null for image radicals.
        /// </summary>
        [JsonProperty("character")]
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets the meanings of the item.
        /// </summary>
        [JsonProperty("meaning")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] Meanings { get; set; }

        /// <summary>
        /// Gets or sets the WaniKani level of the item.
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the user-specific info attached to this item.
        /// </summary>
        [JsonProperty("user_specific")]
        public WaniKaniItemUserInfo UserInfo { get; set; }
    }
}
