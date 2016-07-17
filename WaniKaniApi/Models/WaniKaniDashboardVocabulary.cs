using Newtonsoft.Json;
using WaniKaniApi.Converters;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Represents a vocabulary item as a <see cref="WaniKaniDashboardItem"/>.
    /// </summary>
    public class WaniKaniDashboardVocabulary : WaniKaniDashboardItem
    {
        /// <summary>
        /// Gets or sets the kana readings of the item (will be null for radicals).
        /// </summary>
        [JsonProperty(PropertyName = "kana")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] KanaReadings { get; set; }
    }
}
