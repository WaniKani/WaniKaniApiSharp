using System.Collections.Generic;
using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Response for the vocabulary list requests.
    /// </summary>
    internal class WaniKaniVocabularyListResponse : WaniKaniResponse
    {
        /// <summary>
        /// Gets or sets the vocabulary requested.
        /// </summary>
        [JsonProperty("requested_information")]
        public List<WaniKaniVocabularyItem> Vocabulary { get; set; }
    }
}
