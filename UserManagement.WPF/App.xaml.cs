using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows;
using UserManagement.Core.Interfaces;
using UserManagement.Core.Services;
using UserManagement.Data.Context;
using UserManagement.Data.Repositories;
using UserManagement.WPF.Services;
using UserManagement.WPF.ViewModels;
using UserManagement.WPF.Views;

namespace UserManagement.WPF
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            // DbContext
            services.AddDbContext<UserManagementContext>(options =>
                 options.UseSqlServer(
                     ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                     b => b.MigrationsAssembly("UserManagement.Data")
                 )
             );

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddSingleton<IDialogService, DialogService>();

            // ViewModels
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<UserManagementViewModel>();
            services.AddTransient<AreaAssignmentViewModel>();

            // Views
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = serviceProvider.GetService<MainWindow>();
            if (mainWindow == null)
                throw new InvalidOperationException("Failed to create MainWindow.");

            mainWindow.Show();
        }
    }
}