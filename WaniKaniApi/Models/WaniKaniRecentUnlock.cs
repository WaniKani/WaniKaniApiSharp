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
    /// Item recently unlocked in WaniKani.
    /// </summary>
    public class WaniKaniRecentUnlock
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        public WaniKaniDashboardItem Item { get; set; }

        /// <summary>
        /// Gets or sets the date the item was unlocked.
        /// </summary>
        [JsonProperty(PropertyName = "unlocked_date")]
        [JsonConverter(typeof(WaniKaniDateConverter))]
        public DateTime UnlockedDate { get; set; }
    }
}
