using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ApplicationDbContext
{
    public class ReservoomDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudSocSit;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<MessageModel> Message { get; set; }
        public DbSet<ChatModel> Chat { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<FriendRequestModel> FriendRequest { get; set; }
        public DbSet<FriendsModel> Friends { get; set; }
    }
}
