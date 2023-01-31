namespace vezeeta.DBL.Repos.CenterRepo;

public interface ICenterRepo : IGenericRepo<Center> 
{
    public bool Find(Center center, bool checkName = true);
}