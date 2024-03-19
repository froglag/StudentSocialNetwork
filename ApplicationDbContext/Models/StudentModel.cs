using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationDbContext.Authentication;

namespace ApplicationDbContext.Models;

public class StudentModel
{
    [Key]
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }

    public string? FacultyName { get; set; }
    public string? Specialization { get; set; }

    public string UserId { get; set; }
    public UserModel User { get; set; } = null!;

    public ICollection<FriendshipModel>? Friendships { get; set; }
    public ICollection<FriendshipModel>? FriendshipsAsFriend { get; set; }

    public ICollection<FriendRequestModel>? FriendRequests { get; set; }
    public ICollection<FriendRequestModel>? Requests { get; set; }

    public ICollection<StudentChatModel>? StudentChats { get; set;}
}
