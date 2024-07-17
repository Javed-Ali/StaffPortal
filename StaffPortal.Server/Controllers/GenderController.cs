using Microsoft.AspNetCore.Mvc;
using StaffPortal.Server.BusinessLogic.Services;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gender>>> GetAllGenders()
        {
            var genderList = await _genderService.GetAllGenderAsync();
            return Ok(genderList);
        }
    }
}
