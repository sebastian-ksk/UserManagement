using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserManagement.WPF.Services
{
  

    public class DialogService : IDialogService
    {
        public Task<bool> ShowConfirmAsync(string title, string message)
        {
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);

            return Task.FromResult(result == MessageBoxResult.Yes);
        }

        public Task ShowErrorAsync(string title, string message)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            return Task.CompletedTask;
        }

        public Task ShowInfoAsync(string title, string message)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            return Task.CompletedTask;
        }

        public Task<string> ShowInputAsync(string title, string message, string defaultValue = "")
        {
            // En una implementación real, podrías crear un diálogo personalizado
            // Por ahora usamos el InputBox básico de Windows
            var result = Microsoft.VisualBasic.Interaction.InputBox(
                message,
                title,
                defaultValue);

            return Task.FromResult(result);
        }

        private static Window GetActiveWindow()
        {
            return Application.Current.MainWindow;
        }
    }
}
