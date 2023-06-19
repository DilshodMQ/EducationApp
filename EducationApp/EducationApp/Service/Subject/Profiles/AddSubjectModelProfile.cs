using AutoMapper;
using EducationApp.Service.Subject.Models;

namespace EducationApp.Service.Subject.Profiles
{
    public class AddSubjectModelProfile : Profile
    {
        public AddSubjectModelProfile()
        {
            CreateMap<AddSubjectModel, Data.Subject>();
        }
    }
}
