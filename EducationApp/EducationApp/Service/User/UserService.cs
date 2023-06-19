using AutoMapper;
using EducationApp.Data;
using EducationApp.Exeptions;
using EducationApp.Service.Teacher.Models;
using EducationApp.Service.User.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EducationApp.Service.User
{
    public class UserService : IUserService
    {
        private readonly EducationAppContext _context;
        private readonly IMapper _mapper;
        
        public UserService(EducationAppContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<UserModel>> GetUsersWhoUseBeeline()
        {
            var teachers = _context
                .Teachers
                .Where(tch=>tch.PhoneNumber.StartsWith("+99891")||tch.PhoneNumber.StartsWith("+99890"))
                .AsQueryable();

            var students = _context
                .Students
                .Where(st => st.PhoneNumber.StartsWith("+99891") || st.PhoneNumber.StartsWith("+99890"))
                .AsQueryable();
            if(!teachers.Any()&&!students.Any())
            {
                    throw new ProcessException($"Any student or teacher who use beeline not found");
            }

            IEnumerable<UserModel> teacherData = (await teachers.ToListAsync()).Select(teacher => _mapper.Map<UserModel>(teacher));
            IEnumerable<UserModel> studentData = (await students.ToListAsync()).Select(student => _mapper.Map<UserModel>(student));

            IEnumerable<UserModel> userData = teacherData.Concat(studentData);
         
            return userData;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var users = _context
                .Users
                .Include(u=>u.Role)
                .AsQueryable();

            if (!users.Any())
            {
                throw new ProcessException($"Any user not found");
            }

            IEnumerable<UserModel> userData = (await users.ToListAsync()).Select(user => _mapper.Map<UserModel>(user));          

            return userData;
        }
    }
}
