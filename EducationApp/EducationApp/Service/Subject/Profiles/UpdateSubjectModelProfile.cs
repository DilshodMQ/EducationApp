using AutoMapper;
using EducationApp.Service.Subject.Models;

namespace EducationApp.Service.Subject.Profiles
{
    public class UpdateSubjectModelProfile : Profile
    {
        public UpdateSubjectModelProfile()
        {
            CreateMap<UpdateSubjectModel, Data.Subject>();
        }
    }
}
