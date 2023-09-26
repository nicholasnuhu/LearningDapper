using LearningDapper.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDapper.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User?> GetUser(int id);

        void CreateUser(User user);

        void UpdateUser(User user, int id);

        void DeleteUser(int id);
    }
}