using AutoMapper;
using EducationApp.Service.Subject.Models;

namespace EducationApp.Service.Subject.Profiles
{
    public class SubjectModelProfile : Profile
    {
        public SubjectModelProfile()
        {
            CreateMap<Data.Subject, SubjectModel>();
        }
    }
}
