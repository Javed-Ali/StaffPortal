using Microsoft.EntityFrameworkCore;
using StaffPortal.Server.Data;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.BusinessLogic.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        public async Task<List<Gender>> GetAllGenderAsync()
        {
            return await _genderRepository.GetAllGenders();
        }
    }

}
