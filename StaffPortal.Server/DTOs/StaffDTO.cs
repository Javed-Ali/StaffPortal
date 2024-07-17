namespace StaffPortal.Server.DTOs
{
    public class StaffDTO
    {
        public string EmployeeNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int YearsOfWorkExperience { get; set; }
        public int GenderId { get; set; }
        public int QualificationId { get; set; }
    }
}
