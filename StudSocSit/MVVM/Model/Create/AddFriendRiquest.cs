using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model.Create;

/// <summary>
/// This class provides functionality to send a friend request and handle friend relationships in the database.
/// </summary>
public class AddFriendRiquest
{
    private ReservoomDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddFriendRiquest"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public AddFriendRiquest(ReservoomDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Sends a friend request and establishes a friendship in the database based on the provided request.
    /// </summary>
    /// <param name="request">The request containing information about the friend request.</param>
    public void Do(Request request)
    {
        // Check if a friend request or friendship already exists
        var friendRequest = _context.FriendRequest.FirstOrDefault(fr => fr.SenderId == request.SenderId && fr.ReceiverId == request.ReceiverId);
        var friend = _context.Friends.FirstOrDefault(f => f.StudentId == request.ReceiverId && f.FriendId == request.SenderId);

        // If no existing friend request or friendship, create a new friend request
        if (friendRequest == null && friend == null)
        {
            _context.FriendRequest.Add(new FriendRequestModel
            {
                ReceiverId = request.ReceiverId,
                SenderId = request.SenderId
            });

            // Save changes to the database
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Represents the request format for sending a friend request and establishing a friendship.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Gets or sets the identifier of the student sending the friend request.
        /// </summary>
        public int? SenderId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the student receiving the friend request.
        /// </summary>
        public int? ReceiverId { get; set; }
    }
}
