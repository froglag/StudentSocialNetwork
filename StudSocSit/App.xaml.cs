using StudSocSit.Store;
using System;
using System.Configuration;
using System.Net.Http;
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
        private readonly HttpClient _client;

        public App()
        {
            _navigationStore = new NavigationStore();
            _client = new HttpClient();

            _client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("ApiString"));
        }
            
        protected override void OnStartup(StartupEventArgs e)
        {

            _navigationStore.CurrentViewModel = new LoginVM(_navigationStore, _client);
            var mainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(_navigationStore)
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
