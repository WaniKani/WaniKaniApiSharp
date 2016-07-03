using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaniKaniApi.Models;
using WaniKaniApi.Test.Tools;

namespace WaniKaniApi.Test
{
    [TestClass]
    public class WaniKaniClientTest
    {
        public WaniKaniClient Client;

        public MockApiClient MockApiClient;

        [TestInitialize]
        public void Intialize()
        {
            MockApiClient = new MockApiClient();
            Client = new WaniKaniClient("00000000000000000000000000000000", MockApiClient);
        }

        /// <summary>
        /// Basic test for the GetUserInformation method.
        /// </summary>
        [TestMethod]
        public void GetUserInformationTest()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/UserInformation_01.json");

            // Act
            WaniKaniUserInformation r = Client.GetUserInformation();

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual("Doublevil", r.Username);
            Assert.AreEqual("13c34777f6243ad6f0207962d10c628d", r.GravatarKey);
            Assert.AreEqual(59, r.Level);
            Assert.AreEqual("Turtles", r.Title);
            Assert.AreEqual("About me.\r\nThis text is about me.", r.About);
            Assert.AreEqual("http://houhou-srs.com", r.Website);
            Assert.AreEqual("https://twitter.com/doublevilu", r.Twitter);
            Assert.AreEqual(6, r.TopicsCount);
            Assert.AreEqual(793, r.PostsCount);
            Assert.AreEqual(new DateTime(2013, 03, 26, 20, 55, 46), r.CreationDate);
            Assert.IsNull(r.VacationDate);
        }

        /// <summary>
        /// Basic test for the GetStudyQueue method.
        /// </summary>
        [TestMethod]
        public void GetStudyQueueTest()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/StudyQueue_01.json");

            // Act
            WaniKaniStudyQueue r = Client.GetStudyQueue();

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual(127, r.LessonsAvailable);
            Assert.AreEqual(572, r.ReviewsAvailable);
            Assert.AreEqual(new DateTime(2016, 06, 26, 10, 37, 46), r.NextReviewDate);
            Assert.AreEqual(0, r.ReviewsAvailableNextHour);
            Assert.AreEqual(0, r.ReviewsAvailableNextDay);
        }

        /// <summary>
        /// Basic test for the GetLevelProgression method.
        /// </summary>
        [TestMethod]
        public void GetLevelProgressionTest()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/LevelProgression_01.json");

            // Act
            WaniKaniLevelProgression r = Client.GetLevelProgression();

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual(0, r.RadicalsProgress);
            Assert.AreEqual(1, r.RadicalsTotal);
            Assert.AreEqual(12, r.KanjiProgress);
            Assert.AreEqual(35, r.KanjiTotal);
        }

        /// <summary>
        /// Basic test for the GetSrsDistribution method.
        /// </summary>
        [TestMethod]
        public void GetSrsDistributionTest()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/SrsDistribution_01.json");

            // Act
            WaniKaniSrsDistribution r = Client.GetSrsDistribution();

            // Assert
            Assert.IsNotNull(r);
            Assert.IsNotNull(r.Apprentice);
            Assert.IsNotNull(r.Guru);
            Assert.IsNotNull(r.Master);
            Assert.IsNotNull(r.Enlighten);
            Assert.IsNotNull(r.Burned);
            Assert.AreEqual(0, r.Guru.Radicals);
            Assert.AreEqual(21, r.Guru.Kanji);
            Assert.AreEqual(42, r.Guru.Vocabulary);
            Assert.AreEqual(63, r.Guru.Total);
        }

        /// <summary>
        /// Basic test for the GetRecentUnlocks method. Uses the default limit value.
        /// </summary>
        [TestMethod]
        public void GetRecentUnlocksTest()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/RecentUnlocks_01.json");

            // Act
            List<WaniKaniRecentUnlock> r = Client.GetRecentUnlocks();

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual(3, r.Count);

            Assert.IsNotNull(r[0]);
            Assert.IsNotNull(r[0].Item);
            var v = r[0].Item as WaniKaniDashboardVocabulary;
            Assert.IsNotNull(v);
            Assert.AreEqual("移動", v.Character);
            CollectionAssert.AreEquivalent(new[] { "いどう" }, v.KanaReadings);
            CollectionAssert.AreEquivalent(new[] { "movement", "transfer", "removal", "migration" }, v.Meanings);
            Assert.AreEqual(28, v.Level);
            Assert.AreEqual(new DateTime(2016, 04, 15, 11, 43, 31), r[0].UnlockedDate);

            Assert.IsNotNull(r[1]);
            Assert.IsNotNull(r[1].Item);
            var k = r[1].Item as WaniKaniDashboardKanji;
            Assert.IsNotNull(k);
            CollectionAssert.AreEquivalent(new[] {"せん"}, k.OnYomi);
            CollectionAssert.AreEquivalent(new[] { "うつ", "みやこがえ" }, k.KunYomi);
            CollectionAssert.AreEquivalent(new string[] {}, k.Nanori);
            Assert.AreEqual(WaniKaniReadingType.OnYomi, k.ImportantReading);

            Assert.IsNotNull(r[2]);
            Assert.IsNotNull(r[2].Item);
            var p = r[2].Item as WaniKaniDashboardRadical;
            Assert.IsNotNull(p);
            Assert.IsTrue(string.IsNullOrEmpty(p.ImageUri));
        }

        /// <summary>
        /// Test for the GetRecentUnlocks method. Tests the case where the returned list is empty.
        /// </summary>
        [TestMethod]
        public void GetRecentUnlocks_Empty_Test()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/RecentUnlocks_02.json");

            // Act
            List<WaniKaniRecentUnlock> r = Client.GetRecentUnlocks();

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual(0, r.Count);
        }

        /// <summary>
        /// Basic test for the GetCriticalItems method. Uses the default threshold value.
        /// </summary>
        [TestMethod]
        public void GetCriticalItemsTest()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/CriticalItems_01.json");

            // Act
            List<WaniKaniCriticalItem> r = Client.GetCriticalItems();

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual(1, r.Count);
            Assert.IsNotNull(r[0]);
            Assert.IsNotNull(r[0].Item);
            var k = r[0].Item as WaniKaniDashboardKanji;
            Assert.IsNotNull(k);
            CollectionAssert.AreEquivalent(new[] { "はち" }, k.OnYomi);
            CollectionAssert.AreEquivalent(new[] { "や.*" }, k.KunYomi);
            CollectionAssert.AreEquivalent(new string[] { }, k.Nanori);
            Assert.AreEqual("八", k.Character);
            CollectionAssert.AreEquivalent(new[] { "eight" }, k.Meanings);
            Assert.AreEqual(1, k.Level);
            Assert.AreEqual(WaniKaniReadingType.KunYomi, k.ImportantReading);
            Assert.AreEqual(92, r[0].Percentage);
        }

        /// <summary>
        /// Basic test for the GetRadicals method. Tests the process for level 1 only with a single item.
        /// </summary>
        [TestMethod]
        public void GetRadicals_Single_Test()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/Radicals_01.json");

            // Act
            List<WaniKaniRadicalItem> r = Client.GetRadicals(1);

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual(1, r.Count);
            Assert.IsNotNull(r[0]);
            var p = r[0];
            Assert.IsNull(p.Character);
            CollectionAssert.AreEquivalent(new[] {"stick"}, p.Meanings);
            Assert.AreEqual("https://s3.amazonaws.com/s3.wanikani.com/images/radicals/802e9542627291d4282601ded41ad16ce915f60f.png", p.ImageUri);
            Assert.AreEqual(1, p.Level);
            Assert.IsNotNull(p.UserInfo);
            var u = p.UserInfo;
            Assert.AreEqual(WaniKaniSrsLevel.Burned, u.SrsLevel);
            Assert.AreEqual(9, u.SrsStep);
            Assert.AreEqual(new DateTime(2013, 03, 26, 21, 05, 16), u.UnlockedDate);
            Assert.AreEqual(new DateTime(2013, 09, 20, 12, 30, 00), u.ReviewDate);
            Assert.AreEqual(true, u.IsBurned);
            Assert.AreEqual(new DateTime(2013, 09, 20, 12, 31, 08), u.BurnedDate);
            Assert.AreEqual(8, u.MeaningCorrectAnswers);
            Assert.AreEqual(0, u.MeaningIncorrectAnswers);
            Assert.AreEqual(8, u.MeaningMaxStreak);
            Assert.AreEqual(8, u.MeaningCurrentStreak);
            Assert.IsNull(u.ReadingCorrectAnswers);
            Assert.IsNull(u.ReadingIncorrectAnswers);
            Assert.IsNull(u.ReadingMaxStreak);
            Assert.IsNull(u.ReadingCurrentStreak);
            Assert.IsNull(u.MeaningNote);
            CollectionAssert.AreEquivalent(new string[] {}, u.UserSynonyms);
            Assert.IsNull(u.ReadingNote);
        }

        /// <summary>
        /// Test for the GetRadicals method. Tests that queries are cut in parts for large requests.
        /// </summary>
        /// <remarks>This test assumes that the max level count in a single part is 10. Please adapt it if this value changes.</remarks>
        [TestMethod]
        public void GetRadicals_LargeRequest_Test()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/Radicals_01.json");

            // Act
            List<WaniKaniRadicalItem> r = Client.GetRadicals(1,2,3,4,5,6,7,8,9,10,11,12);

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual(2, r.Count);
            CollectionAssert.AreEquivalent(new[] {
                "/api/v1.4/user/00000000000000000000000000000000/radicals/1,2,3,4,5,6,7,8,9,10",
                "/api/v1.4/user/00000000000000000000000000000000/radicals/11,12" }, MockApiClient.Requests);
        }

        /// <summary>
        /// Basic test for the GetKanji method. Tests the process for level 1 only with a single item.
        /// </summary>
        [TestMethod]
        public void GetKanji_Single_Test()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/Kanji_01.json");

            // Act
            List<WaniKaniKanjiItem> r = Client.GetKanji(1);

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual(1, r.Count);
            Assert.IsNotNull(r[0]);
            var k = r[0];
            CollectionAssert.AreEquivalent(new[] {"こう", "く"}, k.OnYomi);
            CollectionAssert.AreEquivalent(new[] { "くち" }, k.KunYomi);
            CollectionAssert.AreEquivalent(new string[] {}, k.Nanori);
            Assert.AreEqual(WaniKaniReadingType.OnYomi, k.ImportantReading);
            CollectionAssert.AreEquivalent(new[] {"oppose"}, k.UserInfo.UserSynonyms);
        }

        /// <summary>
        /// Basic test for the GetVocabulary method. Tests the process for level 1 only with a single item.
        /// </summary>
        [TestMethod]
        public void GetVocabulary_Single_Test()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/Vocabulary_01.json");

            // Act
            List<WaniKaniVocabularyItem> r = Client.GetVocabulary(1);

            // Assert
            Assert.IsNotNull(r);
            Assert.AreEqual(1, r.Count);
            Assert.IsNotNull(r[0]);
            var v = r[0];
            CollectionAssert.AreEquivalent(new[] {"に"}, v.KanaReadings);
        }

        /// <summary>
        /// Test for errors.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void GetVocabulary_Error_Test()
        {
            // Arrange
            MockApiClient.ReturnValue = File.ReadAllText("Resources/Error_01.json");

            // Act
            List<WaniKaniVocabularyItem> r = Client.GetVocabulary(1);
        }
    }
}
