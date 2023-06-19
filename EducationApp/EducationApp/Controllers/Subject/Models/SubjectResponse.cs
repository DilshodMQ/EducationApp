using EducationApp.Data;

namespace EducationApp.Controllers.Subject.Models
{
    public class SubjectResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? TeacherId { get; set; }

    }
}
