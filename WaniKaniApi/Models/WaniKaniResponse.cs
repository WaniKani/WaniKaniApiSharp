using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Root object returned by the WaniKani API.
    /// </summary>
    internal class WaniKaniResponse
    {
        /// <summary>
        /// Gets or sets the user information.
        /// </summary>
        [JsonProperty(PropertyName = "user_information")]
        public WaniKaniUserInformation UserInformation { get; set; }

        /// <summary>
        /// Gets or sets the error details. Null if there were no errors.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public WaniKaniError Error { get; set; }
    }
}
