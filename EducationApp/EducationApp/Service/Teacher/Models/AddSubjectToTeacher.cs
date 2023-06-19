using System.ComponentModel.DataAnnotations;

namespace EducationApp.Service.Teacher.Models
{
    public class AddSubjectToTeacher
    {
        [Required]
        public int teacherId { get; set; }
        [Required]
        public int subjectId { get; set; }
    }
}
