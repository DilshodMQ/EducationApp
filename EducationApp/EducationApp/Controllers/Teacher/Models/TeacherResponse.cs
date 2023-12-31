﻿using EducationApp.Data;

namespace EducationApp.Controllers.Teacher.Models
{
    public class TeacherResponse
    {
        public int? Id { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
