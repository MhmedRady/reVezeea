using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezeeta.DBL;

public interface IGenericRepo<T> where T : class
{
    List<T> Index();
    public T? GetByID(Guid id);
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public void SaveChanges();
    public  IEnumerable<T>? LoadData();
    public IEnumerable<T>? _Any();
}
