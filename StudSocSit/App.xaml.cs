using ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudSocSit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = "Data Source = reservoom.db";
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(ConnectionString).Options;
            ReservoomDbContext reservoomDbContext = new ReservoomDbContext(options);
            reservoomDbContext.Database.Migrate();
        }
    }
    
 
}
