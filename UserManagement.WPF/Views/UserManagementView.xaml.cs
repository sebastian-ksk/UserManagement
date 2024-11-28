using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using UserManagement.WPF.ViewModels;

namespace UserManagement.WPF.Views
{
    public partial class UserManagementView : UserControl
    {
        private ScrollViewer editSection;

        public UserManagementView()
        {
            InitializeComponent();
            // Buscar el ScrollViewer después de la inicialización
            Loaded += UserManagementView_Loaded;
        }

        private void UserManagementView_Loaded(object sender, RoutedEventArgs e)
        {
            // Encontrar el ScrollViewer por nombre
            editSection = this.FindName("EditSectionScrollViewer") as ScrollViewer;
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // Personalizar las columnas del DataGrid
            switch (e.PropertyName)
            {
                case "FirstName":
                    e.Column.Header = "Nombre";
                    break;
                case "LastName":
                    e.Column.Header = "Apellido";
                    break;
                case "Email":
                    e.Column.Header = "Correo";
                    break;
                case "PhoneNumber":
                    e.Column.Header = "Teléfono";
                    break;
                case "AreaName":
                    e.Column.Header = "Área";
                    break;
                case "IsActive":
                case "Id":
                    e.Cancel = true;
                    break;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Seleccionar todo el texto cuando el TextBox recibe el foco
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // Validar entrada según el campo
                switch (textBox.Name)
                {
                    case "PhoneTextBox":
                        // Solo permitir números y algunos caracteres especiales
                        e.Handled = !Regex.IsMatch(e.Text, @"^[0-9\+\-\(\)]$");
                        break;
                }
            }
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is UserManagementViewModel viewModel)
            {
                if (viewModel.SelectedUser != null)
                {
                    // Asegurar que los campos de edición sean visibles
                    ScrollToEditSection();
                }
            }
        }

        private void ScrollToEditSection()
        {
            // Asegurar que la sección de edición sea visible
            editSection?.Focus();
            editSection?.ScrollToTop();
        }
    }
}