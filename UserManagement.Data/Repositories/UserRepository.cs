using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Interfaces;
using UserManagement.Core.Models;
using UserManagement.Data.Context;

namespace UserManagement.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserManagementContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetLastUsers(int count)
        {
            return await _context.Users
                .Include(u => u.Area)
                .OrderByDescending(u => u.CreatedDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email.ToLower() == email.ToLower() && u.IsActive);
        }

        public async Task<User> GetUserWithAreaAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Area)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersByAreaAsync(int areaId)
        {
            return await _context.Users
                .Include(u => u.Area)
                .Where(u => u.AreaId == areaId && u.IsActive)
                .ToListAsync();
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Area)
                .Where(u => u.IsActive)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToListAsync();
        }
    }
}
