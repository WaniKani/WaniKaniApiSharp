using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaniKaniApi.Models;

namespace WaniKaniApi
{
    /// <summary>
    /// Interface for the capabilities of the WaniKani API.
    /// </summary>
    interface IWaniKaniClient
    {
        /// <summary>
        /// Gets or sets the API key used to communicate with the WaniKani API.
        /// </summary>
        string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the maximum WaniKani level.
        /// </summary>
        int MaxLevel { get; set; }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <returns>User information.</returns>
        WaniKaniUserInformation GetUserInformation();

        /// <summary>
        /// Gets the user information asynchronously.
        /// </summary>
        /// <returns>User information.</returns>
        Task<WaniKaniUserInformation> GetUserInformationAsync();

        /// <summary>
        /// Gets the study queue information.
        /// </summary>
        /// <returns>Study queue information.</returns>
        WaniKaniStudyQueue GetStudyQueue();

        /// <summary>
        /// Gets the study queue information asynchronously.
        /// </summary>
        /// <returns>Study queue information.</returns>
        Task<WaniKaniStudyQueue> GetStudyQueueAsync();

        /// <summary>
        /// Gets the level progression information.
        /// </summary>
        /// <returns>Level progression information.</returns>
        WaniKaniLevelProgression GetLevelProgression();

        /// <summary>
        /// Gets the level progression information asynchronously.
        /// </summary>
        /// <returns>Level progression information.</returns>
        Task<WaniKaniLevelProgression> GetLevelProgressionAsync();

        /// <summary>
        /// Gets the SRS distribution information.
        /// </summary>
        /// <returns>SRS distribution information.</returns>
        WaniKaniSrsDistribution GetSrsDistribution();

        /// <summary>
        /// Gets the SRS distribution information asynchronously.
        /// </summary>
        /// <returns>SRS distribution information.</returns>
        Task<WaniKaniSrsDistribution> GetSrsDistributionAsync();

        /// <summary>
        /// Gets the recently unlocked items.
        /// </summary>
        /// <param name="limit">Maximum number of items to obtain, between 1 and 100 (default is 10).</param>
        /// <returns>Recently unlocked items.</returns>
        List<WaniKaniRecentUnlock> GetRecentUnlocks(int limit = 10);

        /// <summary>
        /// Gets the recently unlocked items asynchronously.
        /// </summary>
        /// <param name="limit">Maximum number of items to obtain, between 1 and 100 (default is 10).</param>
        /// <returns>Recently unlocked items.</returns>
        Task<List<WaniKaniRecentUnlock>> GetRecentUnlocksAsync(int limit = 10);
        
        /// <summary>
        /// Gets the items with a review success percentage under the given threshold.
        /// </summary>
        /// <param name="percentageThreshold">Review success percentage threshold, between 0 and 100. Default is 75.</param>
        /// <returns>List of items with a review success percentage under the given threshold.</returns>
        List<WaniKaniCriticalItem> GetCriticalItems(int percentageThreshold = 75);

        /// <summary>
        /// Gets asynchronously the items with a review success percentage under the given threshold.
        /// </summary>
        /// <param name="percentageThreshold">Review success percentage threshold, between 0 and 100. Default is 75.</param>
        /// <returns>List of items with a review success percentage under the given threshold.</returns>
        Task<List<WaniKaniCriticalItem>> GetCriticalItemsAsync(int percentageThreshold = 75);

        /// <summary>
        /// Gets the list of radicals for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of radicals for the target levels.</returns>
        List<WaniKaniRadicalItem> GetRadicals(params int[] levels);

        /// <summary>
        /// Gets asynchronously the list of radicals for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of radicals for the target levels.</returns>
        Task<List<WaniKaniRadicalItem>> GetRadicalsAsync(params int[] levels);

        /// <summary>
        /// Gets the list of kanji for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of kanji for the target levels.</returns>
        List<WaniKaniKanjiItem> GetKanji(params int[] levels);

        /// <summary>
        /// Gets asynchronously the list of kanji for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of kanji for the target levels.</returns>
        Task<List<WaniKaniKanjiItem>> GetKanjiAsync(params int[] levels);

        /// <summary>
        /// Gets the list of vocabulary items for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of vocabulary items for the target levels.</returns>
        List<WaniKaniVocabularyItem> GetVocabulary(params int[] levels);

        /// <summary>
        /// Gets asynchronously the list of vocabulary items for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of vocabulary items for the target levels.</returns>
        Task<List<WaniKaniVocabularyItem>> GetVocabularyAsync(params int[] levels);
    }
}
