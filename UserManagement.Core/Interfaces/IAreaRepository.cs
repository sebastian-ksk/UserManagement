using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Models;

namespace UserManagement.Core.Interfaces
{
    public interface IAreaRepository : IRepository<Area>
    {
        Task<bool> NameExistsAsync(string areaName);
        Task<IEnumerable<Area>> GetActiveAreasAsync();
        Task<Area> GetAreaWithUsersAsync(int id);
        Task<int> GetUserCountAsync(int areaId);
    }
}
