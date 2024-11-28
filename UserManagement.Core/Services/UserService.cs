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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAreaRepository _areaRepository;

        public UserService(IUserRepository userRepository, IAreaRepository areaRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _areaRepository = areaRepository ?? throw new ArgumentNullException(nameof(areaRepository));
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null ? UserDto.FromModel(user) : null;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(UserDto.FromModel);
        }

        public async Task<IEnumerable<UserDto>> GetLastTenUsersAsync()
        {
            var users = await _userRepository.GetLastUsers(10);
            return users.Select(UserDto.FromModel);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            // Validar email único
            if (await _userRepository.EmailExistsAsync(userDto.Email))
                throw new BusinessException("El email ya está registrado.");

            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Address = userDto.Address,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return UserDto.FromModel(user);
        }

        public async Task UpdateUserContactAsync(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var user = await _userRepository.GetByIdAsync(userDto.Id);
            if (user == null)
                throw new BusinessException($"Usuario con ID {userDto.Id} no encontrado.");

            // Validar email único si cambió
            if (user.Email != userDto.Email && await _userRepository.EmailExistsAsync(userDto.Email))
                throw new BusinessException("El email ya está registrado.");

            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Address = userDto.Address;
            user.ModifiedDate = DateTime.Now;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task AssignUserToAreaAsync(int userId, int areaId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new BusinessException($"Usuario con ID {userId} no encontrado.");

            var area = await _areaRepository.GetByIdAsync(areaId);
            if (area == null)
                throw new BusinessException($"Área con ID {areaId} no encontrada.");

            user.AreaId = areaId;
            user.ModifiedDate = DateTime.Now;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;

            user.IsActive = false;
            user.ModifiedDate = DateTime.Now;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}
