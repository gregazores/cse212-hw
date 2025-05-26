using System.Data.Common;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // first we create a hashset and fill it with the contents of the words
        HashSet<string> wordArray = new HashSet<string>(words);
        //I decided to use List this time instead of an array since the lenght is unknown
        List<string> symmetric = new List<string>();

        foreach (string w in words)
        {
            // we will inverse the current item of the word array
            string inverse = string.Concat(w[1], w[0]);

            // if the letters are the same, the continue statement 
            // skips and moves to the next item on the words array
            if (w[0] == w[1])
            {
                continue;
            }

            // now we check if the inverse version exists in the wordArray hashset
            // if it exist, we concatenate the original and inversed word and add it to our symmetric array
            if (wordArray.Contains(inverse))
            {
                symmetric.Add(string.Concat(w, "&", inverse));
                wordArray.Remove(w);            // notice how we removed the word item 'w' and it's inverse
                wordArray.Remove(inverse);      // this is to ensure nothing is processed again
            }
        }
        return symmetric.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            var degs = fields[3]; // creating a variable to store the degree here

            // of the key degs doesn't exist in our dictionary, we will create the key 
            // and initialize the value to 1
            if (!degrees.ContainsKey(degs))
            {
                degrees.Add(degs, 1);
            }
            else
            {
                degrees[degs] += 1; // if the key does exist then we just increment the value
            }

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // first remove all white spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // quick check if onset the two words differ in length
        // automatic not an anagram
        if (word1.Length != word2.Length)
        {
            return false;
        }

        // inspired from the prev problem we will create a summary of
        // what letters are available and how many times it appears in the word
        // so we will create a dictionary here
        Dictionary<char, int> letterCounts1 = new Dictionary<char, int>();
        Dictionary<char, int> letterCounts2 = new Dictionary<char, int>();

        // based on the prev problem let us evaluate word 1
        foreach (char w in word1)
        {
            if (!letterCounts1.ContainsKey(w))
            {
                letterCounts1.Add(w, 1); // if the letter doesnt exist as a key add it
            }
            else
            {
                letterCounts1[w] += 1; // if the letter exists as key does exist then we just increment the value

            }

        }

        // now we evaluate word 2 this time
        foreach (char w in word2)
        {
            if (!letterCounts2.ContainsKey(w))
            {
                letterCounts2.Add(w, 1); // if the letter doesnt exist as a key add it
            }
            else
            {
                letterCounts2[w] += 1; // if the letter exists as key does exist then we just increment the value

            }

        }

        bool areEqual = letterCounts1.Count == letterCounts2.Count && !letterCounts1.Except(letterCounts2).Any();

        return areEqual;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // so if the feature collection returns null or empty array, we exit by returning an empty array
        if (featureCollection?.Features == null || featureCollection.Features.Count == 0)
        {
            return Array.Empty<string>();
        }

        // using list here to have infinite length 
        List<string> earthquakeData = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            // so each feature item in this instance has a property named Properties
            // we check if among the keys "place" exists if not we skip and move to the next item
            if (!feature.Properties.ContainsKey("place"))
            {
                continue;
            }

            // otherwise, we take the value of the "place" key convert it to string
            // same with magnitude
            string place = feature.Properties["place"].ToString();
            string magnitude = feature.Properties.ContainsKey("mag") ? $"{feature.Properties["mag"]:F1}" : "N/A";

            // add it to our earthquake array which is a List
            // Ensure the format matches expected test output
            earthquakeData.Add($"{place} - Mag {magnitude}");
        }

        return earthquakeData.ToArray();
    }
}