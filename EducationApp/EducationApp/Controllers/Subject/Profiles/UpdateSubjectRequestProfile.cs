using AutoMapper;
using EducationApp.Controllers.Subject.Models;
using EducationApp.Service.Subject.Models;

namespace EducationApp.Controllers.Subject.Profiles
{
    public class UpdateSubjectRequestProfile : Profile
    {
        public UpdateSubjectRequestProfile()
        {
            CreateMap<UpdateSubjectRequest, UpdateSubjectModel>();
        }
    }
}
