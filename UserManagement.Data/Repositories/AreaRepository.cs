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
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(UserManagementContext context) : base(context)
        {
        }

        public async Task<bool> NameExistsAsync(string areaName)
        {
            return await _context.Areas
                .AnyAsync(a => a.AreaName.ToLower() == areaName.ToLower() && a.IsActive);
        }

        public async Task<IEnumerable<Area>> GetActiveAreasAsync()
        {
            return await _context.Areas
                .Include(a => a.Users)
                .Where(a => a.IsActive)
                .OrderBy(a => a.AreaName)
                .ToListAsync();
        }

        public async Task<Area> GetAreaWithUsersAsync(int id)
        {
            var area = await _context.Areas
                .Include(a => a.Users)
                .FirstOrDefaultAsync(a => a.Id == id);

            return area ?? new Area
            {
                Id = 0, // Valor indicativo de que no es un área real
                AreaName = string.Empty,
                IsActive = false,
                CreatedDate = DateTime.MinValue,
                Users = new List<User>() // Lista vacía
            };
        }


        public async Task<int> GetUserCountAsync(int areaId)
        {
            return await _context.Users
                .CountAsync(u => u.AreaId == areaId && u.IsActive);
        }

        public override async Task<IEnumerable<Area>> GetAllAsync()
        {
            return await _context.Areas
                .Include(a => a.Users)
                .Where(a => a.IsActive)
                .OrderBy(a => a.AreaName)
                .ToListAsync();
        }
    }
}
