namespace vezeeta.DBL.Repos.CenterRepo;

public class CenterRepo : GenericRepo<Center>, ICenterRepo
{
    private readonly VezeetaDB _vezeetaDb;

    public CenterRepo(VezeetaDB _vezeetaDB) : base(_vezeetaDB)
    {
        _vezeetaDb = _vezeetaDB;
    }
}