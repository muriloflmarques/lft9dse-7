using Microsoft.EntityFrameworkCore;
using Scm.Domain;

namespace Smc.Infra.Data
{
    public partial class ScmDbContext : DbContext
    {
        public ScmDbContext(DbContextOptions<ScmDbContext> dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Student>()
                .Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(x => x.Surname)
                .HasMaxLength(120)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(x => x.DateOfBirth)
                .IsRequired();

            //Adressess
            //Courses


            modelBuilder.Entity<Address>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Address>()
                .Property(x => x.AddresLineOne)
                .HasMaxLength(120)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(x => x.AddresLineTwo)
                .HasMaxLength(120);

            modelBuilder.Entity<Address>()
                .Property(x => x.City)
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .Property(x => x.CountyOrProvince)
                .HasMaxLength(100);

            //Country




            modelBuilder.Entity<Country>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Country>()
                .Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();



            modelBuilder.Entity<Country>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Course>()
                .Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(x => x.TeacherName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(x => x.StartDate)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(x => x.EndDate)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(x => x.Capacity)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}