using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Radical learned on WaniKani, as returned by the radicals list request.
    /// </summary>
    public class WaniKaniRadicalItem : WaniKaniItem
    {
        /// <summary>
        /// Gets or sets the URI to the image representing the radical. May be null for character radicals.
        /// </summary>
        [JsonProperty("image")]
        public string ImageUri { get; set; }
    }
}
