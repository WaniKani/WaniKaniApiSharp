using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Response for the radicals list requests.
    /// </summary>
    internal class WaniKaniRadicalListResponse : WaniKaniResponse
    {
        /// <summary>
        /// Gets or sets the radicals requested.
        /// </summary>
        [JsonProperty("requested_information")]
        public List<WaniKaniRadicalItem> Radicals { get; set; }
    }
}
