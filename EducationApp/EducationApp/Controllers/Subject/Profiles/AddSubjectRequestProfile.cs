using AutoMapper;
using EducationApp.Controllers.Subject.Models;
using EducationApp.Service.Subject.Models;

namespace EducationApp.Controllers.Subject.Profiles
{
    public class AddSubjectRequestProfile : Profile
    {
        public AddSubjectRequestProfile()
        {
            CreateMap<AddSubjectRequest, AddSubjectModel>();
        }
    }
}
