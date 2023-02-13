using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db;
using vezeeta.DBL.db.Models;

namespace vezeeta.DBL;
public class VezeetaDB : DbContext
{
    #region tables
    public virtual DbSet<User> users { get; set; } = null!;
    public virtual DbSet<Department> departments { get; set; } = null!;
    public virtual DbSet<Center> centers { get; set; } = null!;
    public virtual DbSet<Speciality> specialities { get; set; } = null!;
    public virtual DbSet<CenterSpeciality> centersSpecialities { get; set; } = null!;
    #endregion
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
        modelBuilder.Entity<Center>().ToTable("centers").HasKey(c=>c.Id);
        modelBuilder.Entity<Department>().HasMany(d=>d.Centers).WithOne(c=>c.Department).HasForeignKey(c=>c.DepartmentId);
        modelBuilder.Entity<User>().HasMany(d=>d.Centers).WithOne(c=>c.User).HasForeignKey(c=>c.UserId);

        //modelBuilder.Entity<Center>().HasData(
        //    new Center
        //    {
        //        Id = Guid.NewGuid(),
        //        name_ar = "Center 1",
        //        name_en = "Center 1",
        //        created_at = DateTime.Now,
        //        UserId = Guid.Parse("B2C2EBF4-76E9-4395-9279-DA8DB9A69CBB"),
        //        email = "center1@asp.net",
        //    }
        //);

        // Speciality
        modelBuilder.Entity<Speciality>().ToTable("specialities").HasKey(s => s.Id);

        // CenterSpeciality
        modelBuilder.Entity<CenterSpeciality>().HasKey(m => new { m.SpecialityId, m.CenterId });
        modelBuilder.Entity<Speciality>().HasOne(x => x.MainSpeciality).WithOne().HasForeignKey<Speciality>(x => x.MainSpecialityId);
        modelBuilder.Entity<Speciality>().HasMany(c => c.Centers).WithMany(s => s.Specialities);
        modelBuilder.Entity<Center>().ToTable("centers").HasKey(c => c.Id);
        modelBuilder.Entity<Department>().HasMany(d => d.Centers).WithOne(c => c.Department).HasForeignKey(c => c.DepartmentId);
        modelBuilder.Entity<User>().HasMany(d => d.Centers).WithOne(c => c.User).HasForeignKey(c => c.UserId);


    }
}
