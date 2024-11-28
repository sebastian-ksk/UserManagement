using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UserManagement.Core.DTOs;
using UserManagement.Core.Interfaces;
using UserManagement.WPF.Commands;
using UserManagement.WPF.Services;
using UserManagement.WPF.ViewModels.Base;

namespace UserManagement.WPF.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IDialogService _dialogService;
        private UserDto _selectedUser;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _address;

        public UserManagementViewModel(IUserService userService, IDialogService dialogService)
        {
            _userService = userService;
            _dialogService = dialogService;
            Users = new ObservableCollection<UserDto>();

            CreateUserCommand = new RelayCommand(CreateUser, () => CanCreateUser());
            EditUserCommand = new RelayCommand(EditUser, () => SelectedUser != null);
            LoadUsersCommand = new RelayCommand(LoadUsers);
        }

        public ObservableCollection<UserDto> Users { get; }
        public ICommand CreateUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand LoadUsersCommand { get; }

        public UserDto SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (SetProperty(ref _selectedUser, value))
                {
                    LoadUserDetails();
                }
            }
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private Task CreateUser()
        {
            var newUser = new UserDto
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Address = Address
            };

            return ExecuteAsync(async () =>
            {
                await _userService.CreateUserAsync(newUser);
                await LoadUsers();
                ClearForm();
                await _dialogService.ShowInfoAsync("Éxito", "Usuario creado correctamente.");
            });
        }

        private Task EditUser()
        {
            if (SelectedUser == null)
                return Task.CompletedTask;

            SelectedUser.Email = Email;
            SelectedUser.PhoneNumber = PhoneNumber;
            SelectedUser.Address = Address;

            return ExecuteAsync(async () =>
            {
                await _userService.UpdateUserContactAsync(SelectedUser);
                await LoadUsers();
                await _dialogService.ShowInfoAsync("Éxito", "Usuario actualizado correctamente.");
            });
        }

        private Task LoadUsers()
        {
            return ExecuteAsync(async () =>
            {
                var users = await _userService.GetLastTenUsersAsync();
                Users.Clear();
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            });
        }

        private void LoadUserDetails()
        {
            if (SelectedUser != null)
            {
                FirstName = SelectedUser.FirstName;
                LastName = SelectedUser.LastName;
                Email = SelectedUser.Email;
                PhoneNumber = SelectedUser.PhoneNumber;
                Address = SelectedUser.Address;
            }
        }

        private void ClearForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            SelectedUser = null;
        }

        private bool CanCreateUser()
        {
            return !string.IsNullOrWhiteSpace(FirstName) &&
                   !string.IsNullOrWhiteSpace(LastName) &&
                   !string.IsNullOrWhiteSpace(Email);
        }
    }
}