using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezeeta.DBL;
public class VezeetaDB : DbContext
{
    public virtual DbSet<User> users { get; set; } = null!;

    public VezeetaDB(DbContextOptions<VezeetaDB> dbContextOptions) : base(dbContextOptions) { }
    protected virtual void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
