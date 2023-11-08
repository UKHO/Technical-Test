namespace ChartConversionApp;

public class EntryPoint : IEntryPoint
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

public class ChartHanddalr
{
    private List<AmericanChart> americanCharts;
    private List<NonAmericanChart> nonAmericanCharts;


    public ChartHanddalr(List<AmericanChart> americanCharts, List<NonAmericanChart> nonAmericanCharts)
    {
        this.americanCharts = americanCharts;
        this.nonAmericanCharts = nonAmericanCharts;
    }

    public decimal ConvertMetersToFathoms(decimal meters)
    {
        return Math.Round(meters / (decimal)1.829, 3);
    }
    public decimal ConvertFathomsToMeters(decimal f)
    {
        return f * (decimal)1.829;
    }

    public string GetIdOfDeepestChart()
    {
        AmericanChart deepestAmericanChart;
        decimal depestAmericanPoint = 0;
        foreach (var americanChart in americanCharts)
        {
            
            foreach (var americanChartDataPoint in americanChart.DataPoints)
            {
                if (americanChartDataPoint.depth > depestAmericanPoint)
                {
                    depestAmericanPoint = americanChartDataPoint.depth;
                    deepestAmericanChart = americanChart;
                }
            }
        }

        NonAmericanChart deepestNormalChart = null;
        decimal depestNormalPoint = 0;
        foreach (var nonAmericanChart in nonAmericanCharts)
        {
            foreach (var nonAmericanChartDataPoint in nonAmericanChart.DataPoints)
            {
                if (nonAmericanChartDataPoint.depth > depestNormalPoint)
                {
                    depestNormalPoint = nonAmericanChartDataPoint.depth;
                    deepestNormalChart = nonAmericanChart;
                }
            }
        }

        if (depestNormalPoint > ConvertFathomsToMeters(depestAmericanPoint))
        {
            return deepestNormalChart.Id;
        }
        else
        {
            return deepestAmericanChart.Id;
        }
    }

}

public class AmericanChart
{
    public List<DataPoint> DataPoints { get; }
    public string Id { get; }
    public string Name { get; }

    public AmericanChart(List<DataPoint> dataPoints, string id, string name)
    {
        DataPoints = dataPoints;
        Id = id;
        Name = name;
    }
}

public class NonAmericanChart
{
    public List<DataPoint> DataPoints { get; }
    public string Id { get; }
    public string Name { get; }

    public NonAmericanChart(List<DataPoint> dataPoints, string id, string name)
    {
        DataPoints = dataPoints;
        Id = id;
        Name = name;
    }
}

public class DataPoint
{
    public decimal lat;
    public decimal lon;
    public decimal depth;

    public DataPoint(decimal lat, decimal lon, decimal depth)
    {
        this.lat = lat;
        this.lon = lon;
        this.depth = depth;
    }
}