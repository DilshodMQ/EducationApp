using EducationApp.Controllers.Teacher.Models;
using FluentValidation;

namespace EducationApp.Controllers.Teacher.Validators
{
    public class UpdateTeacherRequestValidator : AbstractValidator<UpdateTeacherRequest>
    {
        public UpdateTeacherRequestValidator()
        {
            RuleFor(teacher => teacher.PhoneNumber).Must(ValidPhoneNumber).WithMessage("Phone number should start with prefix +9989");
            RuleFor(teacher => teacher.Email).EmailAddress();
            RuleFor(teacher => teacher.FirstName).NotEmpty();
            RuleFor(teacher => teacher.LastName).NotEmpty();
            RuleFor(teacher => teacher.BirthDate).NotEmpty();
        }

        private bool ValidPhoneNumber(string phonreNumber)
        {
            if (phonreNumber.StartsWith("+9989"))
                return true;
            return false;
        }
    }
}
