using AutoMapper;
using EducationApp.Service.Teacher.Models;

namespace EducationApp.Service.Teacher.Profiles
{
    public class TeacherModelProfile : Profile
    {
        public TeacherModelProfile()
        {
            CreateMap<Data.Teacher, TeacherModel>();
        }
    }
}
