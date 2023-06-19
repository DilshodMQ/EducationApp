using AutoMapper;
using EducationApp.Service.Student.Models;

namespace EducationApp.Service.Student.Profiles
{
    public class AddStudentmodelProfile : Profile
    {
        public AddStudentmodelProfile()
        {
            CreateMap<AddStudentModel, Data.Student>();
        }
    }
}
