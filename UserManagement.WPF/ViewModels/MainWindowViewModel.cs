using System.Windows.Input;
using UserManagement.WPF.Commands;
using UserManagement.WPF.ViewModels.Base;
using UserManagement.WPF.Views;

namespace UserManagement.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        private readonly UserManagementViewModel _userManagementViewModel;
        private readonly AreaAssignmentViewModel _areaAssignmentViewModel;

        public MainWindowViewModel(
            UserManagementViewModel userManagementViewModel,
            AreaAssignmentViewModel areaAssignmentViewModel)
        {
            _userManagementViewModel = userManagementViewModel;
            _areaAssignmentViewModel = areaAssignmentViewModel;

            // Comandos de navegación
            NavigateToUsersCommand = new RelayCommand(NavigateToUsers);
            NavigateToAreasCommand = new RelayCommand(NavigateToAreas);

            // Establecer vista inicial
            NavigateToUsers();
        }

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand NavigateToUsersCommand { get; }
        public ICommand NavigateToAreasCommand { get; }

        private void NavigateToUsers()
        {
            CurrentView = _userManagementViewModel;
            _userManagementViewModel.LoadUsersCommand?.Execute(null);
        }

        private void NavigateToAreas()
        {
            CurrentView = _areaAssignmentViewModel;
            _areaAssignmentViewModel.LoadDataCommand?.Execute(null);
        }
    }
}