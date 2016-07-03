using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Item under the "critical condition" correct answer percentage, as returned by the WaniKani API.
    /// </summary>
    public class WaniKaniCriticalItem
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        public WaniKaniDashboardItem Item { get; set; }

        /// <summary>
        /// Gets or sets the percentage of accurate answers on the item for the requesting user.
        /// </summary>
        [JsonProperty(PropertyName = "percentage")]
        public int Percentage { get; set; }
    }
}
