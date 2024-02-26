using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;

namespace ApplicationDbContext;

public class ReservoomDbContext : DbContext
{
    

    public ReservoomDbContext(DbContextOptions<ReservoomDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }


    public DbSet<StudentModel> Student { get; set; }
    public DbSet<MessageModel> Message { get; set; }
    public DbSet<ChatModel> Chat { get; set; }
    public DbSet<UserModel> User { get; set; }
    public DbSet<FriendRequestModel> FriendRequest { get; set; }
    public DbSet<FriendshipModel> Friendship { get; set; }
    public DbSet<StudentChatModel> StudentChat { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasOne(u => u.Student)
            .WithOne(s => s.User)
            .HasForeignKey<StudentModel>(u => u.UserId);

        /*---------------------------------------------*/

        modelBuilder.Entity<StudentModel>()
            .HasMany(s => s.Friendships)
            .WithOne(fs => fs.Student)
            .HasForeignKey(s => s.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StudentModel>()
            .HasMany(s => s.FriendshipsAsFriend)
            .WithOne(fs => fs.Friend)
            .HasForeignKey(s => s.FriendId)
            .OnDelete(DeleteBehavior.Restrict);

        /*---------------------------------------------*/

        modelBuilder.Entity<StudentModel>()
            .HasMany(s => s.FriendRequests)
            .WithOne(fr => fr.Sender)
            .HasForeignKey(s => s.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StudentModel>()
            .HasMany(s => s.Requests)
            .WithOne(r => r.Receiver)
            .HasForeignKey(s => s.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);


        /*---------------------------------------------*/

        modelBuilder.Entity<StudentModel>()
            .HasMany(s => s.StudentChats)
            .WithOne(sc => sc.Student)
            .HasForeignKey(s => s.StudentId);

        modelBuilder.Entity<ChatModel>()
            .HasMany(c => c.StudentChats)
            .WithOne(sc => sc.Chat)
            .HasForeignKey(c => c.ChatId);

        /*---------------------------------------------*/

        modelBuilder.Entity<ChatModel>()
            .HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(c => c.ChatId);

    }

}
