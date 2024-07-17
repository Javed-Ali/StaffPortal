using Microsoft.EntityFrameworkCore;
using StaffPortal.Server.Data;
using StaffPortal.Server.DTOs;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.BusinessLogic.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<Staff> CreateStaffAsync(StaffDTO staffDto)
        {
            var staff = new Staff
            {
                EmployeeNumber = staffDto.EmployeeNumber,
                FirstName = staffDto.FirstName,
                LastName = staffDto.LastName,
                DateOfBirth = staffDto.DateOfBirth,
                YearsOfWorkExperience = staffDto.YearsOfWorkExperience,
                GenderId = staffDto.GenderId,
                QualificationId = staffDto.QualificationId,
                Salary = CalculateSalary(staffDto.QualificationId, staffDto.YearsOfWorkExperience)
            };

            return await _staffRepository.CreateAsync(staff);
        }

        public async Task<Staff> GetStaffByEmployeeNumberAsync(string employeeNumber)
        {
            return await _staffRepository.GetByEmployeeNumberAsync(employeeNumber);
        }

        public async Task<Staff> UpdateStaffAsync(string employeeNumber, StaffDTO staffDto)
        {
            var existingStaff = await _staffRepository.GetByEmployeeNumberAsync(employeeNumber);

            if (existingStaff == null)
            {
                throw new InvalidOperationException($"Staff with employee number {employeeNumber} not found.");
            }

            existingStaff.FirstName = staffDto.FirstName;
            existingStaff.LastName = staffDto.LastName;
            existingStaff.DateOfBirth = staffDto.DateOfBirth;

            // Only update these fields; other fields should not be updated via this method

            return await _staffRepository.UpdateAsync(existingStaff);
        }

        public async Task DeleteStaffAsync(string employeeNumber)
        {
            await _staffRepository.DeleteAsync(employeeNumber);
        }

        public decimal CalculateSalary(int qualificationLevel, int yearsOfExperience)
        {
            return (qualificationLevel / 10m) * (yearsOfExperience / 5m) * 100000m;
        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await _staffRepository.GetAllStaff();
        }
 
    }
}
