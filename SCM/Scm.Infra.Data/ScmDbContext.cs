using Microsoft.EntityFrameworkCore;
using Scm.Domain;

namespace Smc.Infra.Data
{
    public partial class ScmDbContext : DbContext
    {
        public ScmDbContext(DbContextOptions<ScmDbContext> dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(st => st.Id);

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

            modelBuilder.Entity<Student>()
                .HasMany(st => st.Addresses)
                .WithOne(ad => ad.Student)
                .HasForeignKey(ad => ad.StudentId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Address>()
                .HasKey(ad => ad.Id);

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

            modelBuilder.Entity<Address>()
                .HasOne(ad => ad.Country)
                .WithMany(coun => coun.Addresses)
                .HasForeignKey(ad => ad.Id);


            modelBuilder.Entity<Country>()
                .HasKey(coun => coun.Id);

            modelBuilder.Entity<Country>()
                .Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();


            modelBuilder.Entity<Course>()
                .HasKey(co => co.Id);

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


            modelBuilder.Entity<StudentCourse>()
                .HasKey(stCo => new { stCo.StudentId, stCo.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(stCo => stCo.Student)
                .WithMany(st => st.StudentCourses)
                .HasForeignKey(stCo => stCo.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(stCo => stCo.Course)
                .WithMany(co => co.StudentCourses)
                .HasForeignKey(stCo => stCo.CourseId);


            modelBuilder.Entity<Country>().HasData(this.GenerateCountries());


            //For the entities with BaseEntity inheritance logical delete is being applied,
            //thus it's necessery to ensure that all the queries will force not to bring
            //deleted elements by using HasQueryFilter
            //this can be overrided by code using IgnoreQueryFilters()
            modelBuilder.Entity<Student>()
                .HasQueryFilter(x => x.DeleteDate == null);

            modelBuilder.Entity<Course>()
                .HasQueryFilter(x => x.DeleteDate == null);


            base.OnModelCreating(modelBuilder);
        }
    }
}