using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Breakdown of all SRS level information.
    /// </summary>
    public class WaniKaniSrsDistribution
    {
        /// <summary>
        /// Gets or sets the information for the Apprentice SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "apprentice")]
        public WaniKaniSrsLevelInfo Apprentice { get; set; }

        /// <summary>
        /// Gets or sets the information for the Guru SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "guru")]
        public WaniKaniSrsLevelInfo Guru { get; set; }

        /// <summary>
        /// Gets or sets the information for the Master SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "master")]
        public WaniKaniSrsLevelInfo Master { get; set; }

        /// <summary>
        /// Gets or sets the information for the Enlighten SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "enlighten")]
        public WaniKaniSrsLevelInfo Enlighten { get; set; }

        /// <summary>
        /// Gets or sets the information for the Burned SRS level.
        /// </summary>
        [JsonProperty(PropertyName = "burned")]
        public WaniKaniSrsLevelInfo Burned { get; set; }
    }
}
