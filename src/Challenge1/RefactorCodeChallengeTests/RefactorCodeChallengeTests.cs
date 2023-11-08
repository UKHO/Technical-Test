using NUnit.Framework;
using RefactorCodeChallenge;

namespace RefactorCodeChallengeTests;

public class RefactorCodeChallengeTests
{
    private CollectionOfShips _testCollectionOfShipsInput;

    private const int ShipOneLength = 70;
    private const int ShipTwoLength = 30;
    private const int ShipThreeLength = 40;
    private const int ShipFourLength = 120;

    private const string ShipOneName = "Bashera";
    private const string ShipTwoName = "Keith";
    private const string ShipThreeName = "Molly";
    private const string ShipFourName = "Rajan";

    [SetUp]
    public void SetUp()
    {
        _testCollectionOfShipsInput = CreateTestCollectionOfShips();
    }

    [Test]
    public void CalculateTotalLengthOfShips_GivenACollectionOfShips_ReturnsTheExpectedTotalLength()
    {

        var expectedTotalLength = ShipOneLength + ShipTwoLength + ShipThreeLength + ShipFourLength;

        var sut = new ShipManager(_testCollectionOfShipsInput);

        var actualTotalLength = sut.CalculateTotalLengthOfShips();

        Assert.That(actualTotalLength, Is.EqualTo(expectedTotalLength));
    }

    [Test]
    public void GetNameOfLongestBattleship_GivenACollectionOfShips_ReturnsTheNameOfTheLongestBattleship()
    {
        var expectedLongestBattleshipName = ShipOneName;

        var sut = new ShipManager(_testCollectionOfShipsInput);

        var actuallongestBattleshipName = sut.GetNameOfLongestBattleship();

        Assert.That(actuallongestBattleshipName, Is.EqualTo(expectedLongestBattleshipName));
    }

    private CollectionOfShips CreateTestCollectionOfShips()
    {
        return new CollectionOfShips
        {
            Battleships = new[] {
                new Battleship
                {
                    Name = ShipOneName,
                    LengthInMeters = ShipOneLength
                },
                new Battleship
                {
                    Name = ShipTwoName,
                    LengthInMeters = ShipTwoLength
                }
            },
            CruiseShips = new[]
            {
                new CruiseShip
                {
                    Name = ShipThreeName,
                    LengthInMeters = ShipThreeLength
                },
                new CruiseShip
                {
                    Name = ShipFourName,
                    LengthInMeters = ShipFourLength
                }
            }
        };
    }
}