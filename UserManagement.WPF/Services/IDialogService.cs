using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.WPF.Services
{
    public interface IDialogService
    {
        Task<bool> ShowConfirmAsync(string title, string message);
        Task ShowErrorAsync(string title, string message);
        Task ShowInfoAsync(string title, string message);
        Task<string> ShowInputAsync(string title, string message, string defaultValue = "");
    }
}
