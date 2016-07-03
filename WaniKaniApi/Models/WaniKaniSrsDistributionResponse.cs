using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Response for the SRS distribution request.
    /// </summary>
    internal class WaniKaniSrsDistributionResponse : WaniKaniResponse
    {
        /// <summary>
        /// Gets or sets the SRS Distribution information.
        /// </summary>
        [JsonProperty(PropertyName = "requested_information")]
        public WaniKaniSrsDistribution SrsDistribution { get; set; }
    }
}
