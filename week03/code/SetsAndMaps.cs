
using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1
     public static string[] FindPairs(string[] words)
{
    var set = new HashSet<string>(words);
    var result = new List<string>();

    foreach (var word in words)
    {
        if (word[0] == word[1]) continue;

        var reversed = $"{word[1]}{word[0]}";

        if (set.Contains(reversed) && string.Compare(word, reversed) < 0)
        {
            result.Add($"{word} & {reversed}");
        }
    }

    return result.ToArray();
}
    // Problem 2
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3].Trim();

            if (!degrees.ContainsKey(degree))
                degrees[degree] = 0;

            degrees[degree]++;
        }

        return degrees;
    }

    // Problem 3
    public static bool IsAnagram(string word1, string word2)
    {
        var w1 = word1.Replace(" ", "").ToLower();
        var w2 = word2.Replace(" ", "").ToLower();

        if (w1.Length != w2.Length)
            return false;

        var dict = new Dictionary<char, int>();

        foreach (var c in w1)
        {
            if (!dict.ContainsKey(c))
                dict[c] = 0;

            dict[c]++;
        }

        foreach (var c in w2)
        {
            if (!dict.ContainsKey(c))
                return false;

            dict[c]--;

            if (dict[c] < 0)
                return false;
        }

        return true;
    }

    // Problem 5 



    public static string[] EarthquakeDailySummary()
{
    try
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = new List<string>();

        foreach (var feature in data.Features)
        {
            result.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
        }

        return result.ToArray();
    }
    catch
    {
        // fallback for no internet
        return ["No data available"];
    }
}

}