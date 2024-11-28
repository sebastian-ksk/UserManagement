using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Models;

namespace UserManagement.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetLastUsers(int count);
        Task<bool> EmailExistsAsync(string email);
        Task<User> GetUserWithAreaAsync(int id);
        Task<IEnumerable<User>> GetUsersByAreaAsync(int areaId);
    }
}
