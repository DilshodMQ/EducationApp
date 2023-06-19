namespace EducationApp.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role(string name, int id)
        {
            Name = name; 
            Id = id;
        }
    }
}
