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
    /// Vocabulary item learned on WaniKani, as returned by the vocabulary list request.
    /// </summary>
    public class WaniKaniVocabularyItem : WaniKaniItem
    {
        /// <summary>
        /// Gets or sets the kana readings of the vocabulary item.
        /// </summary>
        [JsonProperty("kana")]
        [JsonConverter(typeof(WaniKaniMultiValueConverter))]
        public string[] KanaReadings { get; set; }
    }
}
