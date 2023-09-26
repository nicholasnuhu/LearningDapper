using LearningDapper.Core.Interfaces;
using LearningDapper.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDapper.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlClientFactory _clientFactory;

        public UserService(ISqlClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async void CreateUser(User user)
        {
            await _clientFactory.SaveData<dynamic>(storedProcedure: "spUser_Insert", new
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }

        public void DeleteUser(int id)
        {
            _clientFactory.SaveData<dynamic>("spUser_Delete", new
            {
                Id = id
            });
        }

        public async Task<IEnumerable<User>> GetAllUsers() =>
             await _clientFactory.LoadData<User, dynamic>(storedProcedure: "spUser_GetAll", new { });

        public async Task<User?> GetUser(int id)
        {
            var result = await _clientFactory.LoadData<User, dynamic>
                (storedProcedure: "spUser_Get", new { Id = id, });
            return result.FirstOrDefault();
        }

        public async void UpdateUser(User user, int id)
        {
            await _clientFactory.SaveData<dynamic>
                (storedProcedure: "spUser_Update", new
                {
                    Id = id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
        }
    }
}