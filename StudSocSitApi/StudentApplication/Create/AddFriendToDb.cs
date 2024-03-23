using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.Create
{
    /// <summary>
    /// This class provides functionality to add a friendship entry to the database.
    /// </summary>
    public class AddFriendToDb
    {
        private readonly ReservoomDbContext _context;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddFriendToDb"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public AddFriendToDb(ReservoomDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new friendship entry to the database based on the provided request.
        /// </summary>
        /// <param name="request">The request containing information about the friendship.</param>
        public async Task<IResult> Do(Request request)
        {
            var student = await _context.Student.AnyAsync(s => s.StudentId == request.StudentId);
            var friend = await _context.Student.AnyAsync(f => f.StudentId == request.FriendId);
            var findFriendship = await _context.Friendship.AnyAsync(f => (f.StudentId == request.StudentId && f.FriendId == request.FriendId) || (f.StudentId == request.FriendId && f.FriendId == request.StudentId));
            var friendRequests = await _context.FriendRequest
                .FirstOrDefaultAsync(fr => fr.SenderId == request.StudentId && fr.ReceiverId == request.FriendId);

            if (request.StudentId == request.FriendId)
            {
                return Results.BadRequest("Cannot be friends with yourself.");
            }

            if (!student || !friend)
            {
                _logger.LogError("Invalid student or friend identifier.");
                return Results.BadRequest("Invalid student or friend identifier.");
            }

            if (findFriendship)
            {
                _logger.LogError("Friendship already exists.");
                return Results.BadRequest("Friendship already exists.");
            }

            if (friendRequests == null)
            {
                _logger.LogError("You don't have friendRequest.");
                return Results.BadRequest("You don't have friendRequest.");
            }

            FriendshipModel friendshipe = new FriendshipModel()
            {
                StudentId = request.StudentId,
                FriendId = request.FriendId,
            };

            FriendshipModel symmetricFriendship = new FriendshipModel()
            {
                StudentId = request.FriendId,
                FriendId = request.StudentId
            };
            await using var transaction = _context.Database.BeginTransaction();
            try
            {
                await _context.Friendship.AddAsync(friendshipe);
                await _context.Friendship.AddAsync(symmetricFriendship);

                _logger.LogInformation("Friendships succesfully added");


                if (friendRequests != null)
                {
                    _context.Remove(friendRequests);
                }
                await transaction.CommitAsync();

                await _context.SaveChangesAsync();

                _logger.LogInformation("Friendships succesfully added");
                return Results.Created("Friendships succesfully added", new { Friendship = friendshipe, SymmetricFriendship = symmetricFriendship });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError("Not added - exception message: " + ex.Message);
                return Results.Problem(detail: ex.Message);
            }

        }

        /// <summary>
        /// Represents the request format for adding a friendship entry.
        /// </summary>
        public class Request
        {
            /// <summary>
            /// Gets or sets the identifier of the student initiating the friendship.
            /// </summary>
            public int StudentId { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the friend being added.
            /// </summary>
            public int FriendId { get; set; }
        }

    }
}
