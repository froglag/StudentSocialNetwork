using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ApplicationDbContext
{
    public class ReservoomDesingTimeDbContextFactory : IDesignTimeDbContextFactory<ReservoomDbContext>
    {
        public ReservoomDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder().UseSqlite("Data Source=reservoom.db").Options;
            return new ReservoomDbContext(options);
        }
    }
}
