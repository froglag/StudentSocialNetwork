using ApplicationDbContext.Authentication;
using ApplicationDbContext.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDbContext;

public class ReservoomDbContext : IdentityDbContext<UserModel>
{
    public ReservoomDbContext(DbContextOptions<ReservoomDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<UserModel> User {  get; set; }
    public DbSet<StudentModel> Student { get; set; }
    public DbSet<MessageModel> Message { get; set; }
    public DbSet<ChatModel> Chat { get; set; }
    public DbSet<FriendRequestModel> FriendRequest { get; set; }
    public DbSet<FriendshipModel> Friendship { get; set; }
    public DbSet<StudentChatModel> StudentChat { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Student, User entities relationships

        modelBuilder.Entity<StudentModel>()
            .HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<StudentModel>(s => s.UserId);

        //Friedship, Student entities relationships 

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

        //FriedRequest Student entities relationships 

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


        //StudentChat, Chat and student entities relationships 

        modelBuilder.Entity<StudentModel>()
            .HasMany(s => s.StudentChats)
            .WithOne(sc => sc.Student)
            .HasForeignKey(s => s.StudentId);

        modelBuilder.Entity<ChatModel>()
            .HasMany(c => c.StudentChats)
            .WithOne(sc => sc.Chat)
            .HasForeignKey(c => c.ChatId);

        //Chat and messages entities relationships 

        modelBuilder.Entity<ChatModel>()
            .HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(c => c.ChatId);

    }

}
