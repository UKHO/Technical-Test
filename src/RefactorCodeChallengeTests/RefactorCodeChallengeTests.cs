using NUnit.Framework;
using RefactorCodeChallenge;

namespace RefactorCodeChallengeTests;

public sealed class RefactorCodeChallengeTests
{
    //Battleship Lengths
    private const int ShipOneLength = 70;
    private const int ShipTwoLength = 30;
    private const int ShipThreeLength = 40;
    //Cruise Ships Lengths
    private const int ShipFourLength = 120;
    private const int ShipFiveLength = 78;
    private const int ShipSixLength = 48;

    //Battleship Names
    private const string ShipOneName = "Bashera";
    private const string ShipTwoName = "Keith";
    private const string ShipThreeName = "Molly";
    //Cruise Ship Names
    private const string ShipFourName = "Rajan";
    private const string ShipFiveName = "Simon";
    private const string ShipSixName = "Luz";

    private static readonly CollectionOfShips TestCollectionOfShipsInput = CreateTestCollectionOfShips();

    [Test]
    public void CalculateTotalLengthOfShips_GivenACollectionOfShips_ReturnsTheExpectedTotalLength()
    {
        const int expectedTotalLength = ShipOneLength + ShipTwoLength + ShipThreeLength + ShipFourLength +
                                        ShipFiveLength +
                                        ShipSixLength;

        var sut = new ShipManager(TestCollectionOfShipsInput);

        var actualTotalLength = sut.CalculateTotalLengthOfShips();

        Assert.That(actualTotalLength, Is.EqualTo(expectedTotalLength));
    }

    [Test]
    public void GetNameOfLongestBattleship_GivenACollectionOfShips_ReturnsTheNameOfTheLongestBattleship()
    {
        const string expectedShipName = ShipOneName;
        var sut = new ShipManager(TestCollectionOfShipsInput);

        var actualNameOfLongestBattleship = sut.GetNameOfLongestBattleship();

        Assert.That(actualNameOfLongestBattleship, Is.EqualTo(expectedShipName));
    }

    private static CollectionOfShips CreateTestCollectionOfShips()
    {
        return new CollectionOfShips
        {
            Battleships = new[]
            {
                new Battleship
                {
                    Name = ShipOneName,
                    LengthInMeters = ShipOneLength
                },
                new Battleship
                {
                    Name = ShipTwoName,
                    LengthInMeters = ShipTwoLength
                },
                new Battleship
                {
                    Name = ShipThreeName,
                    LengthInMeters = ShipThreeLength
                }
            },
            CruiseShips = new[]
            {
                new CruiseShip
                {
                    Name = ShipFourName,
                    LengthInMeters = ShipFourLength
                },
                new CruiseShip
                {
                    Name = ShipFiveName,
                    LengthInMeters = ShipFiveLength
                },
                new CruiseShip
                {
                    Name = ShipSixName,
                    LengthInMeters = ShipSixLength
                }
            }
        };
    }
}