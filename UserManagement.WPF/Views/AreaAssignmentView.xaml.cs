using System.Windows;
using System.Windows.Controls;
using UserManagement.WPF.ViewModels;

namespace UserManagement.WPF.Views
{
    public partial class AreaAssignmentView : UserControl
    {
        public AreaAssignmentView()
        {
            InitializeComponent();
            this.Loaded += AreaAssignmentView_Loaded;
        }

        private void AreaAssignmentView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is AreaAssignmentViewModel viewModel)
            {
                viewModel.LoadDataCommand.Execute(null);
            }
        }

        private void UsersDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "FullName":
                    e.Column.Header = "Nombre Completo";
                    break;
                case "Email":
                    e.Column.Header = "Correo";
                    break;
                case "AreaName":
                    e.Column.Header = "Área Actual";
                    break;
                case "IsActive":
                case "Id":
                case "PhoneNumber":
                case "Address":
                case "FirstName":
                case "LastName":
                    e.Cancel = true;
                    break;
            }
        }

        private void AreasDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AreaName":
                    e.Column.Header = "Área";
                    break;
                case "UserCount":
                    e.Column.Header = "Cantidad de Usuarios";
                    break;
                case "IsActive":
                case "Id":
                    e.Cancel = true;
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is AreaAssignmentViewModel viewModel &&
                viewModel.SelectedArea != null &&
                viewModel.SelectedUser != null)
            {
                assignButton?.Focus();
            }
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is AreaAssignmentViewModel viewModel &&
                viewModel.SelectedUser != null)
            {
                areaComboBox?.Focus();
            }
        }
    }
}