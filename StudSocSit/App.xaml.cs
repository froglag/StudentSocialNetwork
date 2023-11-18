using ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using StudSocSit.Store;
using System.Configuration;
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
        private readonly NavigationStore _navigationStore;
        public App() => _navigationStore = new NavigationStore();
        protected override void OnStartup(StartupEventArgs e)
        {
            ReservoomDbContext context = new ReservoomDbContext();

            _navigationStore.CurrentViewModel = new LoginVM(context, _navigationStore);
            var mainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(_navigationStore)
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
