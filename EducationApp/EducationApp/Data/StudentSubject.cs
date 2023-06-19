namespace EducationApp.Data
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public int? Rating { get; set; }
    }
}
