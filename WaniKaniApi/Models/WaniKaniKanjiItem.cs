using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WaniKaniApi.Converters;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Kanji learned on WaniKani, as returned by the kanji list request.
    /// </summary>
    public class WaniKaniKanjiItem : WaniKaniItem
    {
        /// <summary>
        /// Gets or sets the on'yomi readings of the kanji.
        /// </summary>
        [JsonProperty("onyomi")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] OnYomi { get; set; }

        /// <summary>
        /// Gets or sets the kun'yomi readings of the kanji.
        /// </summary>
        [JsonProperty("kunyomi")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] KunYomi { get; set; }

        /// <summary>
        /// Gets or sets the nanori readings of the kanji.
        /// </summary>
        [JsonProperty("nanori")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] Nanori { get; set; }

        /// <summary>
        /// Gets or sets the reading used in WaniKani questions for this kanji.
        /// </summary>
        [JsonProperty("important_reading")]
        public WaniKaniReadingType ImportantReading { get; set; }
    }
}
