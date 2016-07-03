using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Represents a radical as a <see cref="WaniKaniDashboardItem"/>.
    /// </summary>
    public class WaniKaniDashboardRadical : WaniKaniDashboardItem
    {
        /// <summary>
        /// Gets or sets the URI to the image representing the radical, when it is an image.
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public string ImageUri { get; set; }
    }
}
