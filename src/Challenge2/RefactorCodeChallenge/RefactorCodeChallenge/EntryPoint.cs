using System.Text.Json;

public class EntryPoint : IEntryPoint
{
    // Todo: 1. Refactor this method to make it more clean, reusable and resilient
    /// <summary>
    /// Downloads and prints the information of the charts
    /// </summary>
    public void PrintChart()
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri("URL")
        };

        var chartsJson = client.GetAsync("charts.json").Result;

        // Todo: 3. The chart json is being updated to have British or American version of depth. The new URL will be: Implement the new chart 
        var charts = JsonSerializer.Deserialize<Chart[]>(chartsJson.Content.ReadAsStringAsync().Result);

        var chartValue = string.Empty;
        foreach (var chart in charts.ToList())
        {
            chartValue += chart.Name + " Long:" + chart.Lat + " Lat:" + chart.Long;
            // Check if British or American and add another field.

            chartValue += Environment.NewLine;
        }

        var chartSummary = new Summary();
        decimal deepest = 0;
        var deepestChartId = "";
        foreach(var chart in charts)
        {
            if (chart.Depth > deepest)
            {
                deepest = chart.Depth;
                deepestChartId = chart.Id;
            }
        }

        chartValue += $"Summary: Deepest ChartId: {deepestChartId} with depth of ";
        if (deepestChartId.StartsWith("GB"))
        {
            chartValue += $"{deepest} meters";
        }
        else
        {
            var deepestInMetres = deepest * (decimal)1.829;
            chartValue += $"{deepestInMetres} meters";
        }

        Console.WriteLine(chartValue);
    }
}