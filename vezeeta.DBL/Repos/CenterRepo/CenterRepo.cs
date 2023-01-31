using Microsoft.EntityFrameworkCore;

namespace vezeeta.DBL.Repos.CenterRepo;

public class CenterRepo : GenericRepo<Center>, ICenterRepo
{
    private readonly VezeetaDB _vezeetaDb;

    public CenterRepo(VezeetaDB _vezeetaDB) : base(_vezeetaDB)
    {
        _vezeetaDb = _vezeetaDB;
    }

    public bool Find(Center center, bool checkName = true)
    {
        if(checkName is true)
        {
            bool center_found = _Any().Any(c => c.name_ar == center.name_ar || c.name_en == center.name_en || c.email == center.email || c.mobile == center.email || c.phone == center.phone);
            return center_found;
        }

        return _Any().Any(c=>c.Id==center.Id);    
    }
    public override IEnumerable<Center>? LoadData()
    {
        return _vezeetaDb.centers.Include(c => c.Department).ToList();
    }
}