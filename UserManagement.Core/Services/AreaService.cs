using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Common.Exceptions;
using UserManagement.Core.DTOs;
using UserManagement.Core.Interfaces;
using UserManagement.Core.Models;

namespace UserManagement.Core.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository ?? throw new ArgumentNullException(nameof(areaRepository));
        }

        public async Task<AreaDto> GetAreaByIdAsync(int id)
        {
            var area = await _areaRepository.GetByIdAsync(id);
            return area != null ? AreaDto.FromModel(area) : null;
        }

        public async Task<IEnumerable<AreaDto>> GetAllAreasAsync()
        {
            var areas = await _areaRepository.GetAllAsync();

            // Check for null areas and replace with empty AreaDto objects
            var areasList = areas.Select(a => a != null ? AreaDto.FromModel(a) : new AreaDto());

            return areasList;
        }

        public async Task<AreaDto> CreateAreaAsync(AreaDto areaDto)
        {
            if (areaDto == null)
                throw new ArgumentNullException(nameof(areaDto));

            // Validar nombre único
            if (await _areaRepository.NameExistsAsync(areaDto.AreaName))
                throw new BusinessException("Ya existe un área con ese nombre.");

            var area = new Area
            {
                AreaName = areaDto.AreaName,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            await _areaRepository.AddAsync(area);
            await _areaRepository.SaveChangesAsync();

            return AreaDto.FromModel(area);
        }

        public async Task UpdateAreaAsync(AreaDto areaDto)
        {
            if (areaDto == null)
                throw new ArgumentNullException(nameof(areaDto));

            var area = await _areaRepository.GetByIdAsync(areaDto.Id);
            if (area == null)
                throw new BusinessException($"Área con ID {areaDto.Id} no encontrada.");

            // Validar nombre único si cambió
            if (area.AreaName != areaDto.AreaName &&
                await _areaRepository.NameExistsAsync(areaDto.AreaName))
                throw new BusinessException("Ya existe un área con ese nombre.");

            areaDto.UpdateModel(area);
            await _areaRepository.UpdateAsync(area);
            await _areaRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAreaAsync(int id)
        {
            var area = await _areaRepository.GetByIdAsync(id);
            if (area == null)
                return false;

            // Verificar si hay usuarios asignados
            if (area.Users.Any())
                throw new BusinessException("No se puede eliminar un área con usuarios asignados.");

            area.IsActive = false;
            await _areaRepository.UpdateAsync(area);
            await _areaRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AreaDto>> GetActiveAreasAsync()
        {
            var areas = await _areaRepository.GetActiveAreasAsync();
            return areas.Select(AreaDto.FromModel);
        }
    }
}
