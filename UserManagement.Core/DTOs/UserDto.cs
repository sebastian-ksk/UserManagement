using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Core.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        public bool IsActive { get; set; }

        // Propiedades de navegación simplificadas
        public string FullName => $"{FirstName} {LastName}";
        public string DisplayName => $"{FullName} - {AreaName ?? "Sin Área"}";

        // Método para crear un DTO desde el modelo
        public static UserDto FromModel(Models.User user)
        {
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                AreaId = user.AreaId,
                AreaName = user.Area?.AreaName,
                IsActive = user.IsActive
            };
        }

        // Método para actualizar el modelo desde el DTO
        public void UpdateModel(Models.User user)
        {
            if (user == null) return;

            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;
            user.PhoneNumber = PhoneNumber;
            user.Address = Address;
            user.AreaId = AreaId;
            user.IsActive = IsActive;
        }
    }
}
