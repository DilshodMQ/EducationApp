namespace EducationApp.Data
{
    public class Teacher : User
    {
        public List<Subject>? Subjects { get; set; } = new();
    }
}
