using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.DTOs;

namespace UserManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<IEnumerable<UserDto>> GetLastTenUsersAsync();
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task UpdateUserContactAsync(UserDto userDto);
        Task AssignUserToAreaAsync(int userId, int areaId);
        Task<bool> DeleteUserAsync(int id);
    }
}
