using ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Model.Get;
using StudSocSit.Store;
using System;
using System.Windows;
using View;
using ViewModel;

namespace StudSocSit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = "Data Source = reservoom.db";
        private readonly NavigationStore _navigationStore;
        private GetStudentInfo.Request _userModel;
        public App() => _navigationStore = new NavigationStore();
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(ConnectionString).Options;
            ReservoomDbContext reservoomDbContext = new ReservoomDbContext(options);
            reservoomDbContext.Database.Migrate();

            var student = new GetStudentInfo(reservoomDbContext).Do(_userModel);
            _navigationStore.CurrentViewModel = new MainPageVM(reservoomDbContext, student);
            var mainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(_navigationStore)
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
