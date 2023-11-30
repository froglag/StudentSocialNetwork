using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Delete
{
    /// <summary>
    /// This class provides functionality to delete a friend request from the database.
    /// </summary>
    public class DeleteFriendRequest
    {
        private ReservoomDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteFriendRequest"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public DeleteFriendRequest(ReservoomDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Deletes a friend request from the database based on the provided friend identifier.
        /// </summary>
        /// <param name="friendId">The identifier of the friend associated with the friend request to be deleted.</param>
        public void Do(int? friendId)
        {
            // Check if friendId is not null before attempting to delete a friend request
            if (friendId != null)
            {
                // Find the friend request based on the sender's identifier
                var friendRequest = _context.FriendRequest.FirstOrDefault(fr => fr.SenderId == friendId);

                // If friend request exists, remove it and save changes to the database
                if (friendRequest != null)
                {
                    _context.FriendRequest.Remove(friendRequest);
                    _context.SaveChanges();
                }
            }
        }
    }
}
