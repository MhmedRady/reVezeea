namespace vezeeta.BL.Managers;

public interface IGenericManager<T> where T : class 
{
    public IEnumerable<T> Index();
    public T? GetByID(Guid id);
    public void Add(T entity);
    public bool Update(T entity);
    public bool Delete(Guid id);
    public bool IsActive(Guid id);
    public bool Activate(Guid id);
    public bool Find(T entity);
    public IEnumerable<T>? LoadData();
}