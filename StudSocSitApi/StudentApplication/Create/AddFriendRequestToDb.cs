using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentApplication.Create;

/// <summary>
/// This class provides functionality to send a findFriend request and handle findFriend relationships in the database.
/// </summary>
public class AddFriendRequestToDb
{
    private readonly ReservoomDbContext _context;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddFriendRequestToDb"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public AddFriendRequestToDb(ReservoomDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Sends a findFriend request and establishes a friendship in the database based on the provided request.
    /// </summary>
    /// <param name="request">The request containing information about the findFriend request.</param>
    public async Task<IResult> Do(Request request)
    {
        // Check if a findFriend request or friendship already exists
        var findFriendRequest = await _context.FriendRequest.AnyAsync(fr => fr.SenderId == request.SenderId && fr.ReceiverId == request.ReceiverId);
        var findFriend = await _context.Friendship.AnyAsync(f => f.StudentId == request.SenderId && f.FriendId == request.ReceiverId);

        // If no existing findFriend request or friendship, create a new findFriend request
        if (findFriend || findFriendRequest)
        {
            _logger.LogError("A friendship request has already been added or a friendship already exists");
            return Results.BadRequest("A friendship request has already been added or a friendship already exists");
        }
        
        FriendRequestModel friendRequest = new FriendRequestModel() 
        {
            SenderId = request.SenderId,
            ReceiverId = request.ReceiverId,
            Text = request.Text,
        };

        await using var transaction = _context.Database.BeginTransaction();
        try
        {
            await _context.FriendRequest.AddAsync(friendRequest);

            // Save changes to the database
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            _logger.LogInformation("A friendship request created");
            return Results.Created("A friendship request created", friendRequest);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError("Not added - exception message: " + ex.Message);
            return Results.Problem(detail: ex.Message);
        }

        
    }

    /// <summary>
    /// Represents the request format for sending a findFriend request and establishing a friendship.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Gets or sets the identifier of the student sending the findFriend request.
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the student receiving the findFriend request.
        /// </summary>
        public int ReceiverId { get; set; }

        public string? Text { get; set; }
    }
}
