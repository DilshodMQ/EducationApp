using EducationApp.Data;

namespace EducationApp.Controllers.Student.Models
{
    public class StudentResponse
    {
        public int? Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int StudentRegNumber { get; set; }

    }
}
