using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;


namespace ApplicationDbContext
{
    public class ReservoomDbContext : DbContext
    {
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<MessageModel> Message { get; set; }
        public DbSet<ChatModel> Chat { get; set; }
        public DbSet<NewsModel> News { get; set; }

        public ReservoomDbContext(DbContextOptions options):base(options)
        {
            
        }

    }
}
