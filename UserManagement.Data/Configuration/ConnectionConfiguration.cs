using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Common.Exceptions;

namespace UserManagement.Data.Configuration
{
    public static class ConnectionConfiguration
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static void ValidateConnection()
        {
            var connectionString = GetConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new BusinessException("La cadena de conexión 'DefaultConnection' no está configurada en el archivo App.config");
            }
        }
    }
}
