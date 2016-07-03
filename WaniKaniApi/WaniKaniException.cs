using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaniKaniApi.Models;

namespace WaniKaniApi
{
    /// <summary>
    /// Represents an error that occured on WaniKani's side.
    /// </summary>
    public class WaniKaniException : Exception
    {
        /// <summary>
        /// Gets the error that occured on WaniKani's side.
        /// </summary>
        public WaniKaniError WaniKaniError { get; }

        /// <summary>
        /// Builds a WaniKaniException with the given error.
        /// </summary>
        /// <param name="error">Error from the WaniKani API.</param>
        public WaniKaniException(WaniKaniError error)
            : base($"An error occured while communicating with the WaniKani API. See the {nameof(WaniKaniError)} property for more information.")
        {
            WaniKaniError = error;
        }
    }
}
