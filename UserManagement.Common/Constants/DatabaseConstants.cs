using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Common.Constants
{
    public static class DatabaseConstants
    {
        // Nombres de Tablas
        public const string UsersTable = "Users";
        public const string AreasTable = "Areas";

        // Longitudes máximas
        public const int MaxNameLength = 100;
        public const int MaxEmailLength = 255;
        public const int MaxPhoneLength = 20;
        public const int MaxAddressLength = 500;

        // Mensajes de Error
        public const string EmailAlreadyExists = "Ya existe un usuario con este correo electrónico.";
        public const string AreaNameAlreadyExists = "Ya existe un área con este nombre.";
        public const string UserNotFound = "Usuario no encontrado.";
        public const string AreaNotFound = "Área no encontrada.";
        public const string AreaHasUsers = "No se puede eliminar el área porque tiene usuarios asignados.";

        // Procedimientos Almacenados
        public const string SpGetLastTenUsers = "sp_GetLastTenUsers";
        public const string SpUpdateUserContact = "sp_UpdateUserContact";
        public const string SpAssignUserToArea = "sp_AssignUserToArea";
        public const string SpCreateUser = "sp_CreateUser";

        // Áreas predeterminadas
        public static readonly string[] DefaultAreas = new[]
        {
            "Nomina",
            "Facturación",
            "Servicio al Cliente",
            "IT"
        };
    }
}
