using System;
using Newtonsoft.Json;
using WaniKaniApi.Converters;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// User information matching the API key, as returned by the WaniKani API.
    /// </summary>
    public class WaniKaniUserInformation
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the key to the user-defined Gravatar.
        /// </summary>
        [JsonProperty(PropertyName = "gravatar")]
        public string GravatarKey { get; set; }

        /// <summary>
        /// Gets or sets the current WaniKani level of the user.
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the forum title (or sect) of the user.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the user-defined "about me" information.
        /// </summary>
        [JsonProperty(PropertyName = "about")]
        public string About { get; set; }

        /// <summary>
        /// Gets or sets the link to a user-defined website.
        /// </summary>
        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the link to a user-defined Twitter account.
        /// </summary>
        [JsonProperty(PropertyName = "twitter")]
        public string Twitter { get; set; }

        /// <summary>
        /// Gets or sets the number of forum topics created by the user.
        /// </summary>
        [JsonProperty(PropertyName = "topics_count")]
        public int TopicsCount { get; set; }

        /// <summary>
        /// Gets or sets the number of forum posts written by the user.
        /// </summary>
        [JsonProperty(PropertyName = "posts_count")]
        public int PostsCount { get; set; }

        /// <summary>
        /// Gets or sets the user account creation date.
        /// </summary>
        [JsonProperty(PropertyName = "creation_date")]
        [JsonConverter(typeof(WaniKaniDateConverter))]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the last "vacation mode" activation date, when vacation mode is active.
        /// </summary>
        [JsonProperty(PropertyName = "vacation_date")]
        [JsonConverter(typeof(WaniKaniDateConverter))]
        public DateTime? VacationDate { get; set; }
    }
}
