using AutoMapper;
using EducationApp.Service.Teacher.Models;

namespace EducationApp.Service.Teacher.Profiles
{
    public class UpdateTeacherModelProfile : Profile
    {
        public UpdateTeacherModelProfile()
        {
            CreateMap<UpdateTeacherModel, Data.Teacher>();
        }
    }
}
