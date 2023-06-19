using AutoMapper;
using EducationApp.Controllers.Student.Models;
using EducationApp.Service.Student.Models;

namespace EducationApp.Controllers.Student.Profiles
{
    public class AddStudentRequestProfile : Profile
    {
        public AddStudentRequestProfile()
        {
            CreateMap<AddStudentRequest, AddStudentModel>();
        }
        
    }
}
