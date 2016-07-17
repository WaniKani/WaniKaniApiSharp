using System.Collections.Generic;
using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Response for the kanji list requests.
    /// </summary>
    internal class WaniKaniKanjiListResponse : WaniKaniResponse
    {
        /// <summary>
        /// Gets or sets the kanji requested.
        /// </summary>
        [JsonProperty("requested_information")]
        public List<WaniKaniKanjiItem> Kanji { get; set; }
    }
}
