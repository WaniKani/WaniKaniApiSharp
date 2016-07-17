using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Breakdown of SRS items in a WaniKani SRS level.
    /// </summary>
    public class WaniKaniSrsLevelInfo
    {
        /// <summary>
        /// Gets or sets the number of radicals in the SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "radicals")]
        public int Radicals { get; set; }

        /// <summary>
        /// Gets or sets the number of kanji in the SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "kanji")]
        public int Kanji { get; set; }

        /// <summary>
        /// Gets or sets the number of vocabulary in the SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "vocabulary")]
        public int Vocabulary { get; set; }

        /// <summary>
        /// Gets or sets the total number of items in the SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }
}
