using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        // Problem 1: Symmetric word pairs
        HashSet<string> seen = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip words like "aa"

            string reversed = new string(word.Reverse().ToArray());
            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            seen.Add(word);
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 5)
            {
                string degree = fields[4].Trim();
                if (!degrees.ContainsKey(degree))
                {
                    degrees[degree] = 1;
                }
                else
                {
                    degrees[degree]++;
                }
            }
        }
        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        Dictionary<char, int> GetLetterCounts(string word)
        {
            var counts = new Dictionary<char, int>();
            foreach (char c in word.ToLower())
            {
                if (char.IsWhiteSpace(c)) continue;
                if (!counts.ContainsKey(c))
                {
                    counts[c] = 1;
                }
                else
                {
                    counts[c]++;
                }
            }
            return counts;
        }

        var counts1 = GetLetterCounts(word1);
        var counts2 = GetLetterCounts(word2);

        return counts1.Count == counts2.Count && !counts1.Except(counts2).Any();
    }

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

        List<string> results = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties.Place;
            var mag = feature.Properties.Mag;

            if (!string.IsNullOrWhiteSpace(place) && mag.HasValue)
            {
                results.Add($"{place} - Mag {mag.Value}");
            }
        }

        return results.ToArray();
    }

    // Supporting classes for Earthquake JSON
    public class FeatureCollection
    {
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public string Place { get; set; }
        public double? Mag { get; set; }
    }
}
