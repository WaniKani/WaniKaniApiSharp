using System;
using Newtonsoft.Json;
using WaniKaniApi.Converters;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Information about the user's current study queue.
    /// </summary>
    public class WaniKaniStudyQueue
    {
        /// <summary>
        /// Gets or sets the number of lessons in the queue.
        /// </summary>
        [JsonProperty(PropertyName = "lessons_available")]
        public int LessonsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the number of reviews in the queue.
        /// </summary>
        [JsonProperty(PropertyName = "reviews_available")]
        public int ReviewsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the next review date.
        /// </summary>
        [JsonProperty(PropertyName = "next_review_date")]
        [JsonConverter(typeof(WaniKaniDateConverter))]
        public DateTime NextReviewDate { get; set; }

        /// <summary>
        /// Gets or sets the number of reviews available in the next 60 minutes.
        /// </summary>
        [JsonProperty(PropertyName = "reviews_available_next_hour")]
        public int ReviewsAvailableNextHour { get; set; }

        /// <summary>
        /// Gets or sets the number of reviews available in the next 24 hours.
        /// </summary>
        [JsonProperty(PropertyName = "reviews_available_next_day")]
        public int ReviewsAvailableNextDay { get; set; }
    }
}
