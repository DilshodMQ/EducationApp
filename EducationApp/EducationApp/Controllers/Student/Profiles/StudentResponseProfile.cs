using AutoMapper;
using EducationApp.Controllers.Student.Models;
using EducationApp.Service.Student.Models;

namespace EducationApp.Controllers.Student.Profiles
{
    public class StudentResponseProfile : Profile
    {
        public StudentResponseProfile()
        {
            CreateMap<StudentModel, StudentResponse>();
        }
    }
}
