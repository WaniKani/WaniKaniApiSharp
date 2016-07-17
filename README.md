# WaniKaniApiSharp
A complete WaniKani API client for .net

## Description
WaniKaniApiSharp is a .net library that allows you to easily query the [official WaniKani API](https://www.wanikani.com/api).

The currently supported API version is **V1.4**.

Everything featured in the official WaniKani API documentation is implemented. All query methods are XML documented and unit tested.

## Usage
The main class you will be using is ```WaniKaniApi.WaniKaniClient```. You can instantiate it with an API key:
```csharp
var client = new WaniKaniApi.WaniKaniClient("EnterYourApiKeyHere");
```
Using the client is very simple. Here is the list of queries you can use:
```csharp
client.GetUserInformation();
client.GetStudyQueue();
client.GetLevelProgression();
client.GetSrsDistribution();
client.GetRecentUnlocks();
client.GetCriticalItems();
client.GetRadicals();
client.GetKanji();
client.GetVocabulary();
```
Also note that each query has an asynchronous version:
```csharp
WaniKaniApi.Models.WaniKaniLevelProgression result = await client.GetLevelProgressionAsync();
```

#### Example
Here is an example showing a random kanji from the first three levels, with its level and current SRS step:
```csharp
var client = new WaniKaniApi.WaniKaniClient("EnterYourApiKeyHere");
var kanjiList = client.GetKanji(1, 2, 3);
var random = new System.Random();
var kanji = kanjiList[random.Next(kanjiList.Count)];
System.Console.WriteLine(string.Format("{0} is WK level {1} and is currently {2}", kanji.Character, kanji.Level, kanji.UserInfo.SrsLevel));
// Example output would be: "川 is WK level 1 and is currently Burned"
```

## Contribution
If you notice something wrong or think a feature is missing, file an issue here on GitHub.

If you want to make a pull request, please make sure that all unit tests are passing, and be sure to add new unit tests for your features when it is relevant.

## License
The library is available under the MIT License.
