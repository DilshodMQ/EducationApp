namespace EducationApp.Data
{
    public class Student : User
    {
        public int StudentRegNumber { get; set; }

        public ICollection<StudentSubject>? StudentSubjects { get; set; }
    }
}
