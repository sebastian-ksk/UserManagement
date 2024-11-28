using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Core.DTOs
{
    public class AreaDto
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public bool IsActive { get; set; }
        public int UserCount { get; set; }

        // Lista de usuarios en el área (simplificada)
        public List<string> UserNames { get; set; } = new List<string>();

        // Método para crear un DTO desde el modelo
        public static AreaDto FromModel(Models.Area area)
        {
            if (area == null) return null;

            return new AreaDto
            {
                Id = area.Id,
                AreaName = area.AreaName,
                IsActive = area.IsActive,
                UserCount = area.Users?.Count ?? 0,
                UserNames = area.Users?
                    .Where(u => u.IsActive)
                    .Select(u => u.FullName)
                    .ToList() ?? new List<string>()
            };
        }

        // Método para actualizar el modelo desde el DTO
        public void UpdateModel(Models.Area area)
        {
            if (area == null) return;

            area.AreaName = AreaName;
            area.IsActive = IsActive;
        }

        public override string ToString()
        {
            return AreaName;
        }
    }
}
