namespace RefactorCodeChallenge;

public interface IManagerMaker
{
    IShipManager MakeManager(CollectionOfShips collectionOfShips);
}