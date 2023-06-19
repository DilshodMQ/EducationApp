using AutoMapper;
using EducationApp.Service.User.Models;

namespace EducationApp.Service.User.Profiles
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<Data.Teacher, UserModel>();
            CreateMap<Data.Student, UserModel>();
            CreateMap<Data.User, UserModel>();
        }
    }
}
