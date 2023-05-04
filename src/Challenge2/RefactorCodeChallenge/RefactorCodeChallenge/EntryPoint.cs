using System.Text.Json;

namespace RefactorCodeChallenge;

public class EntryPoint : IEntryPoint
{
    //TODO 1 - Get json of charts from web
    //TODO 2 - Get deepest point on chart and print
    //TODO 3 - List Charts in Alphabetical order by ID
    //TODO 4 - Get chart with widest area
    private const string ApiEndPoint = "TODO";

    public void Run()
    {
        var client = new HttpClient();

        client.BaseAddress = new Uri(ApiEndPoint);

        var result = client.GetAsync("charts.json").Result;

        var jsonResult = JsonSerializer.Deserialize<Chart[]>(result.Content.ReadAsStringAsync().Result);

    }
}

public class DisplayOutputs
{
    private ChartAnalyser chartAnalyser;

    public DisplayOutputs()
    {
        chartAnalyser = new ChartAnalyser();
    }

    public void GenerateStandardOutput(Chart[] charts)
    {
        var chartsOrdered = chartAnalyser.GetChartsAlphabetically(charts);
        var chartDeepestPoint = chartAnalyser.GetChartWithDeepestPoint(charts);
        var chartLargestArea = chartAnalyser.GetChartWithLargestArea(charts);

        Console.WriteLine($"The chart with the greatest area is {chartLargestArea.Id} - {chartLargestArea.Name} with an area of {chartLargestArea.Area} meters squared.");
        Console.WriteLine($"The chart with the deepest point is {chartDeepestPoint.Id} - {chartDeepestPoint.Name} with a depth of X");
        Console.WriteLine($"The charts are:");
        foreach (var chart in chartsOrdered)
        {
            Console.WriteLine($"{chart.Id} - {chart.Name}");
        }
        Console.ReadLine();
    }
}

public interface IChartAnalyser
{
    Chart[] GetChartsAlphabetically(Chart[] charts);
    Chart GetChartWithDeepestPoint(Chart[] charts);
    Chart GetChartWithLargestArea(Chart[] charts);
}

public class ChartAnalyser : IChartAnalyser
{
    public Chart[] GetChartsAlphabetically(Chart[] charts)
    {
        throw new NotImplementedException();
    }

    public Chart GetChartWithDeepestPoint(Chart[] charts)
    {
        throw new NotImplementedException();
    }

    public Chart GetChartWithLargestArea(Chart[] charts)
    {
        throw new NotImplementedException();
    }
}

public class Chart
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Sounding[] Soundings { get; set; }
    public int Area { get; set; }
    public bool American { get; set; }
}

public class Sounding
{
    public int latitude { get; set; }
    public int longitude { get; set; }
    public int depth { get; set; }
}