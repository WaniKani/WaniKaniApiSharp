using System;
using System.Threading.Tasks;

namespace WaniKaniApi.ApiClient
{
    /// <summary>
    /// Interface for the API communication layer.
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// Interrogates the api with the given uri, and returns its response as a string.
        /// </summary>
        /// <param name="uri">Uri to interrogate.</param>
        /// <returns>Result of the query as a Json string.</returns>
        Task<string> QueryApiAsync(Uri uri);
    }
}
