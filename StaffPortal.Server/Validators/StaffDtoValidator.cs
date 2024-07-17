using FluentValidation;
using StaffPortal.Server.DTOs;

namespace StaffPortal.Server.Validators
{
    public class StaffDtoValidator : AbstractValidator<StaffDTO>
    {
        public StaffDtoValidator()
        {
            RuleFor(x => x.EmployeeNumber).NotEmpty().Length(1, 20);
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 50);
            RuleFor(x => x.LastName).NotEmpty().Length(1, 50);
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.YearsOfWorkExperience).GreaterThanOrEqualTo(0);
            RuleFor(x => x.GenderId).NotEmpty();
            RuleFor(x => x.QualificationId).NotEmpty();
        }
    }
}
