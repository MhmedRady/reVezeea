using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db;

namespace vezeeta.DBL;
public class VezeetaDB : DbContext
{
    public virtual DbSet<User> users { get; set; } = null!;
    public virtual DbSet<Department> departments { get; set; } = null!;
    //public virtual DbSet<Center> centers { get; set; } = null!;
    public VezeetaDB(DbContextOptions<VezeetaDB> dbContextOptions) : base(dbContextOptions) { }
    protected virtual void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<User>().ToTable("users").HasKey(d=>d.Id);

        // Department
        modelBuilder.Entity<Department>().ToTable("departments").HasKey(d=>d.Id);
        modelBuilder.Entity<Department>().Property(d => d.created_at).HasDefaultValueSql("getdate()");

        // Center
        /*modelBuilder.Entity<Center>().ToTable("centers").HasKey(c=>c.Id);
        modelBuilder.Entity<Department>().HasMany(d=>d.Centers).WithOne(c=>c.Department).HasForeignKey(c=>c.DepartmentId);
        modelBuilder.Entity<User>().HasMany(d=>d.Centers).WithOne(c=>c.User).HasForeignKey(c=>c.UserId);*/

    }
}
