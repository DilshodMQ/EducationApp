using AutoMapper;
using EducationApp.Service.Student.Models;

namespace EducationApp.Service.Student.Profiles
{
    public class StudentModelProfile : Profile
    {
        public StudentModelProfile()
        {
            CreateMap<Data.Student, StudentModel>();
        }
    }
}
