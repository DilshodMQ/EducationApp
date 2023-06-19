using EducationApp.Controllers.Student.Models;
using FluentValidation;

namespace EducationApp.Controllers.Student.Validators
{
    public class AddStudentRequestValidator : AbstractValidator<AddStudentRequest>
    {
        public AddStudentRequestValidator()
        {
            RuleFor(student => student.PhoneNumber).Must(ValidPhoneNumber).WithMessage("Phone number should start with prefix +9989");
            RuleFor(student => student.Email).EmailAddress();
            RuleFor(student => student.FirstName).NotEmpty();
            RuleFor(student => student.LastName).NotEmpty();
            RuleFor(student => student.BirthDate).NotEmpty();
            RuleFor(student => student.StudentRegNumber).NotEmpty();
        }

        private bool ValidPhoneNumber(string phonreNumber)
        {
            if(phonreNumber.StartsWith("+9989"))
            return true;
            return false;
        }
    }
}
