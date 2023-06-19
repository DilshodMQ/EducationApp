using EducationApp.Service.User.Models;

namespace EducationApp.Service.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsersWhoUseBeeline();
        public Task<IEnumerable<UserModel>> GetAllUsers();
    }
}
