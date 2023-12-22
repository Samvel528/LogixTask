using LogixTask.Domain.Enums;
using LogixTask.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogixTask.Entities.Context
{
    public class LogixTaskDbContext : DbContext
    {
        public LogixTaskDbContext(DbContextOptions<LogixTaskDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=F:\\SQLite\\LogixTaskDb.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<UserClass> UserClass { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClass>()
                .HasKey(uc => new { uc.UserId, uc.ClassId });

            modelBuilder.Entity<UserClass>()
                .HasOne(uc => uc.Class)
                .WithMany(uc => uc.UserClasses)
                .HasForeignKey(uc => uc.ClassId);

            modelBuilder.Entity<UserClass>()
                .HasOne(uc => uc.User)
                .WithMany(uc => uc.UserClasses)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserType>().HasData(
                new UserType
                {
                    Id = 1,
                    Name = "Admin"
                },
                new UserType
                {
                    Id = 2,
                    Name = "User"
                }
            );

            modelBuilder.Entity<User>().HasData(
                            new User
                            {
                                Id = 1,
                                Email = "admin@admin.org",
                                Password = "admin12345",
                                FirstName = "Samvel",
                                LastName = "Hovhannisyan",
                                FullName = "Samvel Hovhannisyan",
                                DateOfBirth = DateTime.Now.ToString("MM/dd/yyyy"),
                                Address = "859 ADAMS AVE 7",
                                PhoneNumber = "(999) 999 - 9999",
                                UserTypeId = (int)UserTypeEnum.Admin,
                            }
                        );

            modelBuilder.Entity<Class>().HasData(
                new Class
                {
                    Id = 1,
                    Name = "C#/OOP",
                },
                new Class
                {
                    Id = 2,
                    Name = "Java/OOP",
                },
                new Class
                {
                    Id = 3,
                    Name = "C++",
                }
            );
        }
    }
}
