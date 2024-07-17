using Microsoft.AspNetCore.Mvc;
using StaffPortal.Server.BusinessLogic.Services;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService _qualificationService;
        public QualificationController(IQualificationService qualificationService)
        {
            _qualificationService = qualificationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Qualification>>> GetAllQualifications ()
        {
            var qualificationList = await _qualificationService.GetAllQualificationsAsync();
            return Ok(qualificationList);
        }
    }
}
