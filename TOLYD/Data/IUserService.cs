using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TOLYD.Classes;

namespace TOLYD.Data
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(string username);
        Task<int> SaveUserAsync(User user);
        Task<int> DeleteUserAsync(User user);
    }
}
