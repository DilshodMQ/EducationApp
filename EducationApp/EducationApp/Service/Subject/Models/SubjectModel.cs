using EducationApp.Data;

namespace EducationApp.Service.Subject.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? TeacherId { get; set; }

        public ICollection<StudentSubject>? StudentSubjects { get; set; }
    }
}
