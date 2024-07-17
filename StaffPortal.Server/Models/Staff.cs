using System.Reflection;

namespace StaffPortal.Server.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfWorkExperience { get; set; }
        public int GenderId { get; set; }
        public int QualificationId { get; set; }
        public Gender? Gender { get; set; }
        public Qualification? Qualification { get; set; }
    }
}
