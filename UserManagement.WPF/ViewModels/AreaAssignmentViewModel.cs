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
    public class AreaAssignmentViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IAreaService _areaService;
        private readonly IDialogService _dialogService;
        private UserDto _selectedUser;
        private AreaDto _selectedArea;

        public AreaAssignmentViewModel(
            IUserService userService,
            IAreaService areaService,
            IDialogService dialogService)
        {
            _userService = userService;
            _areaService = areaService;
            _dialogService = dialogService;
            Users = new ObservableCollection<UserDto>();
            Areas = new ObservableCollection<AreaDto>();
            AssignAreaCommand = new RelayCommand(AssignArea, () => CanAssignArea());
            LoadDataCommand = new RelayCommand(LoadData);
        }

        public ObservableCollection<UserDto> Users { get; }
        public ObservableCollection<AreaDto> Areas { get; }
        public ICommand AssignAreaCommand { get; }
        public ICommand LoadDataCommand { get; }

        public UserDto SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        public AreaDto SelectedArea
        {
            get => _selectedArea;
            set => SetProperty(ref _selectedArea, value);
        }

        private Task LoadData()
        {
            return ExecuteAsync(async () =>
            {
                var users = await _userService.GetAllUsersAsync();
                var areas = await _areaService.GetAllAreasAsync();
                Users.Clear();
                Areas.Clear();
                foreach (var user in users)
                {
                    Users.Add(user);
                }
                foreach (var area in areas)
                {
                    Areas.Add(area);
                }
            });
        }

        private Task AssignArea()
        {
            if (SelectedUser == null || SelectedArea == null)
                return Task.CompletedTask;

            return ExecuteAsync(async () =>
            {
                await _userService.AssignUserToAreaAsync(SelectedUser.Id, SelectedArea.Id);
                await LoadData();
                await _dialogService.ShowInfoAsync("Éxito", "Usuario asignado al área correctamente.");
            });
        }

        private bool CanAssignArea()
        {
            return SelectedUser != null && SelectedArea != null;
        }
    }
}