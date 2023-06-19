using System.ComponentModel.DataAnnotations;

namespace EducationApp.Service.Student.Models
{
    public class AddSubjectToStudentModel
    {
        [Required]
        public int studentId { get; set; }
        [Required]
        public int subjectId { get; set; }
    }
}
