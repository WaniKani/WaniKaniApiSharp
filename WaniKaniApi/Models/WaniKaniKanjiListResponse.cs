using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
