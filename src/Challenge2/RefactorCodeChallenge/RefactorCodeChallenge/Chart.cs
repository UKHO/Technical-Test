public class Chart
{
    public decimal Long { get; set; }   
    public decimal Lat { get; set; }

    public string? Name { get; set; }
    public decimal Depth { get; internal set; }
    public string? Id { get; internal set; }
}