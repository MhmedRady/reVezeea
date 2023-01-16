using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL;

namespace vezeeta.DBL;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly VezeetaDB vezeetaDB;

    public GenericRepo(VezeetaDB _vezeetaDB)
    {
        this.vezeetaDB = _vezeetaDB;
    }

    public void Add(T entity)
    {
        vezeetaDB.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        vezeetaDB.Set<T>().Remove(entity);
    }

    public List<T> Index()
    {
        return this.vezeetaDB.Set<T>().ToList();
    }

    public T? GetByID(Guid id)
    {
        return this.vezeetaDB.Set<T>().Find(id);
    }

    public void Update(T entity)
    {
        vezeetaDB.Set<T>().Update(entity);
    }

    void IGenericRepo<T>.SaveChanges()
    {

        this.vezeetaDB.SaveChanges();

    }
    
    public IEnumerable<T>? LoadData()
    {
        return (from repo in this.Index()
                select repo);
    }

    public IEnumerable<T>? _Any()
    {
        return this.vezeetaDB.Set<T>();
    }
}
