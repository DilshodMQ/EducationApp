﻿namespace EducationApp.Data
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Teacher? Teacher { get; set; }

        public int? TeacherId { get; set; }

        public ICollection<StudentSubject>? StudentSubjects { get; set; }
    }
}
