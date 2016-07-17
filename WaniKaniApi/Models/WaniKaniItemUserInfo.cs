using System;
using Newtonsoft.Json;
using WaniKaniApi.Converters;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Contains user-specific information that attaches to a <see cref="WaniKaniItem"/>.
    /// </summary>
    public class WaniKaniItemUserInfo
    {
        /// <summary>
        /// Gets or sets the current SRS level of the item.
        /// </summary>
        [JsonProperty("srs")]
        public WaniKaniSrsLevel SrsLevel { get; set; }

        /// <summary>
        /// Gets or sets the numeric SRS step of the item, ranging from 1 (Apprentice step 1) to 9 (Burned).
        /// </summary>
        [JsonProperty("srs_numeric")]
        public int SrsStep { get; set; }

        /// <summary>
        /// Gets or sets the date the item was unlocked.
        /// </summary>
        [JsonProperty("unlocked_date")]
        [JsonConverter(typeof(WaniKaniDateConverter))]
        public DateTime UnlockedDate { get; set; }

        /// <summary>
        /// Gets or sets the next review date for the item, or the last review date if the item is burned.
        /// Null if the user is on vacation mode.
        /// </summary>
        [JsonProperty("available_date")]
        [JsonConverter(typeof(WaniKaniDateConverter))]
        public DateTime? ReviewDate { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating if the item is burned.
        /// </summary>
        [JsonProperty("burned")]
        public bool IsBurned { get; set; }

        /// <summary>
        /// Gets or sets the date the item was burned.
        /// </summary>
        [JsonProperty("burned_date")]
        [JsonConverter(typeof(WaniKaniDateConverter))]
        public DateTime? BurnedDate { get; set; }

        /// <summary>
        /// Gets or sets the number of correct answers on the meaning question.
        /// </summary>
        [JsonProperty("meaning_correct")]
        public int MeaningCorrectAnswers { get; set; }

        /// <summary>
        /// Gets or sets the number of incorrect answers on the meaning question.
        /// </summary>
        [JsonProperty("meaning_incorrect")]
        public int MeaningIncorrectAnswers { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of correct answers on the meaning question in a row.
        /// </summary>
        [JsonProperty("meaning_max_streak")]
        public int MeaningMaxStreak { get; set; }

        /// <summary>
        /// Gets or sets the current streak of correct answers on the meaning question.
        /// </summary>
        [JsonProperty("meaning_current_streak")]
        public int MeaningCurrentStreak { get; set; }

        /// <summary>
        /// Gets or sets the number of correct answers on the reading question. Null for radicals.
        /// </summary>
        [JsonProperty("reading_correct")]
        public int? ReadingCorrectAnswers { get; set; }

        /// <summary>
        /// Gets or sets the number of incorrect answers on the reading question. Null for radicals.
        /// </summary>
        [JsonProperty("reading_incorrect")]
        public int? ReadingIncorrectAnswers { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of correct answers on the reading question in a row. Null for radicals.
        /// </summary>
        [JsonProperty("reading_max_streak")]
        public int? ReadingMaxStreak { get; set; }

        /// <summary>
        /// Gets or sets the current streak of correct answers on the reading question. Null for radicals.
        /// </summary>
        [JsonProperty("reading_current_streak")]
        public int? ReadingCurrentStreak { get; set; }

        /// <summary>
        /// Gets or sets the user note for the meaning.
        /// </summary>
        [JsonProperty("meaning_note")]
        public string MeaningNote { get; set; }

        /// <summary>
        /// Gets or sets the user-defined synonyms for the meaning question.
        /// </summary>
        [JsonProperty("user_synonyms", NullValueHandling = NullValueHandling.Ignore)]
        public string[] UserSynonyms { get; set; } = new string[] {};

        /// <summary>
        /// Gets or sets the user note for the reading.
        /// </summary>
        [JsonProperty("reading_note")]
        public string ReadingNote { get; set; }
    }
}
