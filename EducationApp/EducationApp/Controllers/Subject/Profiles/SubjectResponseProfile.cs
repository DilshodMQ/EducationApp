using AutoMapper;
using EducationApp.Controllers.Subject.Models;
using EducationApp.Service.Subject.Models;

namespace EducationApp.Controllers.Subject.Profiles
{
    public class SubjectResponseProfile : Profile
    {
        public SubjectResponseProfile()
        {
            CreateMap<SubjectModel, SubjectResponse>();
        }
    }
}
