using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.DTOs;

namespace UserManagement.Core.Interfaces
{
    public interface IAreaService
    {
        Task<AreaDto> GetAreaByIdAsync(int id);
        Task<IEnumerable<AreaDto>> GetAllAreasAsync();
        Task<AreaDto> CreateAreaAsync(AreaDto areaDto);
        Task UpdateAreaAsync(AreaDto areaDto);
        Task<bool> DeleteAreaAsync(int id);
        Task<IEnumerable<AreaDto>> GetActiveAreasAsync();
    }
}
