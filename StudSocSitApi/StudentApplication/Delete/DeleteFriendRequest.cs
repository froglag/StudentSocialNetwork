using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.Delete;

/// <summary>
/// This class provides functionality to delete a friend request from the database.
/// </summary>
public class DeleteFriendRequest
{
    private readonly ReservoomDbContext _context;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteFriendRequest"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="logger"></param>
    public DeleteFriendRequest(ReservoomDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Deletes a friend request from the database based on the provided friend identifier.
    /// </summary>
    /// <param name="request">The identifier of the friend associated with the friend request to be deleted.</param>
    public async Task<IResult> Do(Request request)
    {
        // Find the friend request based on the sender's identifier
        var friendRequest = await _context.FriendRequest.FirstOrDefaultAsync(fr => fr.SenderId == request.SenderId && fr.ReceiverId == request.ReceiverId);

        if (friendRequest == null)
        {
            _logger.LogError("Friend request Not found");
            return Results.NotFound("Friend request Not found");
        }

        

        var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.FriendRequest.Remove(friendRequest);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            _logger.LogInformation("Friend request successfully removed");
            return Results.Ok("Friend request successfully removed");
        }catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError("Couldn't remove friend request: " + ex.Message);
            return Results.Problem(detail: ex.Message);
        }
        
    }
    public class Request
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    } 
}
