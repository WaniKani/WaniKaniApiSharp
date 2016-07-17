using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// WaniKani response for the study queue query.
    /// </summary>
    internal class WaniKaniStudyQueueResponse : WaniKaniResponse
    {
        /// <summary>
        /// Gets or sets the study queue information.
        /// </summary>
        [JsonProperty(PropertyName = "requested_information")]
        public WaniKaniStudyQueue StudyQueue { get; set; }
    }
}
