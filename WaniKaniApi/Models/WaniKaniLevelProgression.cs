using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Level progression information from the WaniKani API.
    /// </summary>
    public class WaniKaniLevelProgression
    {
        /// <summary>
        /// Gets or sets the number of radicals of the current level that attained the Guru SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "radicals_progress")]
        public int RadicalsProgress { get; set; }

        /// <summary>
        /// Gets or sets the number of radicals on this level.
        /// </summary>
        [JsonProperty(PropertyName = "radicals_total")]
        public int RadicalsTotal { get; set; }

        /// <summary>
        /// Gets or sets the number of kanji of the current level that attained the Guru SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "kanji_progress")]
        public int KanjiProgress { get; set; }

        /// <summary>
        /// Gets or sets the number of kanji on this level.
        /// </summary>
        [JsonProperty(PropertyName = "kanji_total")]
        public int KanjiTotal { get; set; }
    }
}
