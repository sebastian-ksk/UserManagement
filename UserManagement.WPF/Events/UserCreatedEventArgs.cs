using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.DTOs;

namespace UserManagement.WPF.Events
{
    public class UserCreatedEventArgs : EventArgs
    {
        public UserDto CreatedUser { get; }

        public UserCreatedEventArgs(UserDto createdUser)
        {
            CreatedUser = createdUser ?? throw new ArgumentNullException(nameof(createdUser));
        }
    }

    public class UserUpdatedEventArgs : EventArgs
    {
        public UserDto UpdatedUser { get; }

        public UserUpdatedEventArgs(UserDto updatedUser)
        {
            UpdatedUser = updatedUser ?? throw new ArgumentNullException(nameof(updatedUser));
        }
    }

    public class AreaAssignedEventArgs : EventArgs
    {
        public UserDto User { get; }
        public int AreaId { get; }

        public AreaAssignedEventArgs(UserDto user, int areaId)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            AreaId = areaId;
        }
    }
}
