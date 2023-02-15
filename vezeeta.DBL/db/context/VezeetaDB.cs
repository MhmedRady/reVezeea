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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        /* MODELS DATA */
        // User
        modelBuilder.Entity<User>().ToTable("users").HasKey(d=>d.Id);

        // Department
        modelBuilder.Entity<Department>().ToTable("departments").HasKey(d=>d.Id);
        modelBuilder.Entity<Department>().Property(d => d.created_at).HasDefaultValueSql("GETDATE()");
        
        // Center
        modelBuilder.Entity<Center>().ToTable("centers").HasKey(c=>c.Id);
        modelBuilder.Entity<Department>().HasMany(d=>d.Centers).WithOne(c=>c.Department).HasForeignKey(c=>c.DepartmentId);
        modelBuilder.Entity<User>().HasMany(d=>d.Centers).WithOne(c=>c.User).HasForeignKey(c=>c.UserId);
        modelBuilder.Entity<Center>().HasMany(d=>d.Specialities).WithMany(c=>c.Centers);
        modelBuilder.Entity<Center>().Property(d => d.created_at).HasDefaultValueSql("GETDATE()");
        
        // Speciality
        modelBuilder.Entity<Speciality>().ToTable("specialities").HasKey(s => s.Id);
        modelBuilder.Entity<Speciality>().HasOne(x => x.MainSpeciality);
        modelBuilder.Entity<Speciality>().Property(d => d.created_at).HasDefaultValueSql("GETDATE()");
        
        // CenterSpeciality
        modelBuilder.Entity<Speciality>().HasMany(c => c.Centers)
            .WithMany(s => s.Specialities).UsingEntity<CenterSpeciality>(cs =>
            {
                cs.Property(sc=>sc.CreatedAt).HasDefaultValueSql("GETDATE()");
                cs.HasKey(k => new { k.SpecialityId, k.CenterId });
            });
        
        /************************************************************************************************************************/
        
        /* SEEDING DATA */
        // Center
        modelBuilder.Entity<Center>().HasData(
            new Center
            {
                Id = Guid.NewGuid(),
                name_ar = "Center 1",
                name_en = "Center 1",
                phone = "01234567890",
                email = "center1@asp.net",
            },
            new Center
            {
                Id = Guid.NewGuid(),
                name_ar = "Center 2",
                name_en = "Center 2",
                phone = "01234567891",
                email = "center2@asp.net",
            },
            new Center
            {
                Id = Guid.NewGuid(),
                name_ar = "Center 3",
                name_en = "Center 3",
                phone = "01234567892",
                email = "center3@asp.net",
            }
        );
        
        // Speciality
        // modelBuilder.Entity<Speciality>().HasData(
        //     new Speciality
        //     {
        //         Id = Guid.NewGuid(),
        //         name_ar = "MainSpeciality 1",
        //         name_en = "MainSpeciality 1",
        //     },
        //     new Speciality
        //     {
        //         Id = Guid.NewGuid(),
        //         name_ar = "MainSpeciality 2",
        //         name_en = "MainSpeciality 2",
        //     }
        // );
    }
}
