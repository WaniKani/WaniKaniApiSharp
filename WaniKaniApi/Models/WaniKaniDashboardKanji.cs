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
    /// Represents a kanji as a <see cref="WaniKaniDashboardItem"/>.
    /// </summary>
    public class WaniKaniDashboardKanji : WaniKaniDashboardItem
    {
        /// <summary>
        /// Gets or sets the on'yomi readings of the item, when it is a kanji.
        /// </summary>
        [JsonProperty("onyomi")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] OnYomi { get; set; }

        /// <summary>
        /// Gets or sets the kun'yomi readings of the item, when it is a kanji.
        /// </summary>
        [JsonProperty("kunyomi")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] KunYomi { get; set; }

        /// <summary>
        /// Gets or sets the nanori readings of the item, when it is a kanji.
        /// </summary>
        [JsonProperty("nanori")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] Nanori { get; set; }

        /// <summary>
        /// Gets or sets the important reading of the item (the one used in quizz), when it is a kanji.
        /// </summary>
        [JsonProperty("important_reading")]
        public WaniKaniReadingType ImportantReading { get; set; }
    }
}
