using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.context;
using vezeeta.DBL.Repos;

namespace vezeeta.DBL.Repos;

public class GenericRepo<T> : IGenericRepo<T>
{
    private readonly VezeetaDB vezeetaDB;

    public GenericRepo(VezeetaDB _vezeetaDB)
    {
        this.vezeetaDB = _vezeetaDB;
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public List<T> Index()
    {
        throw new NotImplementedException();
    }

    public T? Show(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    void IGenericRepo<T>.SaveChanges()
    {
        this.vezeetaDB.SaveChanges();
    }

}
