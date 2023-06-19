using AutoMapper;
using EducationApp.Service.Teacher.Models;

namespace EducationApp.Service.Teacher.Profiles
{
    public class AddTeacherModelProfile : Profile
    {
        public AddTeacherModelProfile()
        {
            CreateMap<AddTeacherModel, Data.Teacher>();
        }
    }
}
