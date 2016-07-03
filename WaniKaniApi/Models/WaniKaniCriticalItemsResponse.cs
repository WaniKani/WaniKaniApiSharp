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
    /// Response for the critical items request.
    /// </summary>
    internal class WaniKaniCriticalItemsResponse : WaniKaniResponse
    {
        /// <summary>
        /// Gets or sets the critical items.
        /// </summary>
        [JsonProperty(PropertyName = "requested_information")]
        [JsonConverter(typeof(WaniKaniDashboardItemConverter))]
        public List<WaniKaniCriticalItem> CriticalItems { get; set; }
    }
}
