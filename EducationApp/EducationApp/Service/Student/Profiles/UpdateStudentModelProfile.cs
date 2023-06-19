using AutoMapper;
using EducationApp.Service.Student.Models;

namespace EducationApp.Service.Student.Profiles
{
    public class UpdateStudentModelProfile : Profile
    {
        public UpdateStudentModelProfile()
        {
            CreateMap<UpdateStudentModel, Data.Student>();
        }
    }
}
