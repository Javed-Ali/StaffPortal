using Microsoft.EntityFrameworkCore;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedGenders(modelBuilder);
            SeedQualifications(modelBuilder);
            SeedStaff(modelBuilder);
        }

        private static void SeedGenders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Description = "Male" },
                new Gender { Id = 2, Description = "Female" }
            );
        }

        private static void SeedQualifications(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Qualification>().HasData(
                new Qualification { Id = 1, Level = 5, Description = "Diploma" },
                new Qualification { Id = 2, Level = 6, Description = "Degree" },
                new Qualification { Id = 3, Level = 7, Description = "Post Graduate" },
                new Qualification { Id = 4, Level = 8, Description = "Master’s Degree" }
            );
        }

        private static void SeedStaff(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    EmployeeNumber = "EMP001",
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1985, 10, 15),
                    YearsOfWorkExperience = 5,
                    GenderId = 1, // 1 is Male
                    QualificationId = 2 // 2 is Degree
                },
                new Staff
                {
                    Id = 2,
                    EmployeeNumber = "EMP002",
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1990, 5, 20),
                    YearsOfWorkExperience = 3,
                    GenderId = 2, // 2 is Female
                    QualificationId = 3 // 3 is Post Graduate
                }
            // Add more staff members as needed
            );
        }
    }
}
