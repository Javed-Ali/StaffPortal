using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffPortal.Server.BusinessLogic.Services;
using StaffPortal.Server.DTOs;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
         
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] StaffDTO staffDto)
        {
            var existingStaff = await _staffService.GetStaffByEmployeeNumberAsync(staffDto.EmployeeNumber);
            if (existingStaff != null)
            {
                return Conflict("Employee Number already exists. Please use a different Employee Number.");
            }

            var staff = await _staffService.CreateStaffAsync(staffDto);
            return CreatedAtAction(nameof(GetStaffByEmployeeNumber), new { employeeNumber = staff.EmployeeNumber }, staff);
        }

        [HttpGet("{employeeNumber}")]
        public async Task<IActionResult> GetStaffByEmployeeNumber(string employeeNumber)
        {
            var staff = await _staffService.GetStaffByEmployeeNumberAsync(employeeNumber);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            var staffList = await _staffService.GetAllStaffAsync();
            return Ok(staffList);
        }

        [HttpPut("{employeeNumber}")]
        public async Task<IActionResult> UpdateStaff(string employeeNumber, [FromBody] StaffDTO staffDto)
        {
            try
            {
                var staff = await _staffService.GetStaffByEmployeeNumberAsync(employeeNumber);
                if (staff == null)
                {
                    return NotFound();
                }

                // Validate staffDto before updating
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                staff = await _staffService.UpdateStaffAsync(employeeNumber, staffDto);

                return NoContent(); 
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{employeeNumber}")]
        public async Task<IActionResult> DeleteStaff(string employeeNumber)
        {
            try
            {
                var staff = await _staffService.GetStaffByEmployeeNumberAsync(employeeNumber);
                if (staff == null)
                {
                    return NotFound();
                }

                await _staffService.DeleteStaffAsync(employeeNumber);
                // Return a success response
                return NoContent(); // HTTP 204 No Content
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }  
        }
    }
}
