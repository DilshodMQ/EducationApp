using Microsoft.EntityFrameworkCore;

namespace EducationApp.Data
{
    public class EducationAppContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<StudentSubject> StudentSubjects { get; set; }

        public EducationAppContext(DbContextOptions<EducationAppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role("Admin", 1),
                                                new Role("Teacher", 2),
                                                new Role("Student", 3));
            modelBuilder.Entity<User>().HasData(new User
            {
                Id= 1,
                Password="admin123",
                FirstName = "Admin",
                LastName = "Adminov",
                BirthDate = new DateTime(1985, 02, 08),
                Email = "admin@mail.com",
                RoleId =1,
                PhoneNumber = "+998999543420"
            });
        }
    }
}
