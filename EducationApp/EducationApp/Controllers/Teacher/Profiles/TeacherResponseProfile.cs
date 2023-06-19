using AutoMapper;
using EducationApp.Controllers.Teacher.Models;
using EducationApp.Service.Teacher.Models;

namespace EducationApp.Controllers.Teacher.Profiles
{
    public class TeacherResponseProfile : Profile
    {
        public TeacherResponseProfile()
        {
            CreateMap<TeacherModel, TeacherResponse>();  
        }
    }
}
