namespace ChartConversionApp.Test
{
    public class Tests
    {
#pragma warning disable CS8618
        private ChartHanddalr _chartHandaler;
#pragma warning restore CS8618

        [SetUp]
        public void Setup()
        {
            var americanDataPoints1 = new List<DataPoint> { new(10, 13, 1), new(10, 14, 2) };
            var americanDataPoints2 = new List<DataPoint> { new(10, 13, 1), new(10, 14, 2) };
            var nonAmericanDataPoints1 = new List<DataPoint> { new(10, 13, 1), new(10, 14, 2) };
            var nonAmericanDataPoints2 = new List<DataPoint> { new(10, 13, 1), new(10, 14, 2) };
            var americanCharts = new List<AmericanChart>
            {
                new(americanDataPoints1, "US123", "AmericanChart123"),
                new(americanDataPoints2, "US345", "AmericanChart345")
            };
            var nonAmericanCharts = new List<NonAmericanChart>
            {
                new(nonAmericanDataPoints1, "GB123", "BritishChart123"),
                new(nonAmericanDataPoints2, "DE123", "GermanChart123")
            };
            _chartHandaler = new ChartHanddalr(americanCharts, nonAmericanCharts);
        }

        [TestCase(1, 0.547)]
        [TestCase(21, 11.482)]
        [TestCase(137, 74.904)]
        public void TestCanConvertFathomsToMeters(decimal input, decimal expected)
        {
            var result = _chartHandaler.ConvertMetersToFathoms(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, 1.829)]
        [TestCase(75, 137.175)]
        [TestCase(12, 21.948)]
        public void TestCanConvertMetersToFathoms(decimal input, decimal expected)
        {
            var result = _chartHandaler.ConvertFathomsToMeters(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}