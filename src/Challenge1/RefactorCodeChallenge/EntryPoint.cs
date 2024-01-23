using Newtonsoft.Json;

namespace RefactorCodeChallenge;

public class EntryPoint : IEntryPoint
{
    private readonly IManagerMaker _managerMaker;

    private const string ApiEndPoint = "https://raw.githubusercontent.com/UKHO/Technical-Test/Development/FixMissingApi/src/Challenge1/ExampleData/";

    public EntryPoint(IManagerMaker managerMaker)
    {
        _managerMaker = managerMaker;
    }

    public void Run()
    {
        var client = new HttpClient();

        client.BaseAddress = new Uri(ApiEndPoint);

        var thing = client.GetAsync("ships.json").Result;

        var jsonResult = JsonConvert.DeserializeObject<CollectionOfShips>(thing.Content.ReadAsStringAsync().Result);

        var shipManager = _managerMaker.MakeManager(jsonResult);

        Console.WriteLine($"The longest battleship is {shipManager.GetNameOfLongestBattleship()}");
        Console.WriteLine($"The total length of all the ships is {shipManager.CalculateTotalLengthOfShips()}");

        Console.WriteLine("Press enter key to exit...");
        Console.ReadLine();
    }
}

public class ShipManagerMaker : IManagerMaker
{
    public IShipManager MakeManager(CollectionOfShips collectionOfShips) => new ShipManager(collectionOfShips);
}

public class ShipManager : IShipManager
{
    private readonly CollectionOfShips _collectionOfShips;

    public ShipManager(CollectionOfShips collectionOfShips)
    {
        _collectionOfShips = collectionOfShips;
    }

    public int CalculateTotalLengthOfShips()
    {
        var length = _collectionOfShips.Battleships[0].LengthInMeters;
        length += _collectionOfShips.Battleships[1].LengthInMeters;
        length += _collectionOfShips.Battleships[2].LengthInMeters;

        length += _collectionOfShips.CruiseShips[0].LengthInMeters;
        length += _collectionOfShips.CruiseShips[1].LengthInMeters;
        length += _collectionOfShips.CruiseShips[2].LengthInMeters;

        return length;
    }

    public string GetNameOfLongestBattleship()
    {
        var longestShipLength = 0;
        Battleship longestShip = null;
        foreach (var ship in _collectionOfShips.Battleships)
        {
            if (ship.LengthInMeters > longestShipLength)
                longestShip = ship;
        }

        return longestShip.Name;
    }
}

public class CollectionOfShips
{
    public Battleship[] Battleships { get; set; }
    public CruiseShip[] CruiseShips { get; set; }
}

public class Battleship
{
    public string Name { get; set; }
    public int NumberOfGuns { get; set; }
    public int LengthInMeters { get; set; }
    public bool Helipad { get; set; }
}

public class CruiseShip
{
    public string Name { get; set; }
    public int NumberOfEmergencyRIBs { get; set; }
    public int LengthInMeters { get; set; }
    public string[] Features { get; set; }
}