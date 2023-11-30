using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model.Create
{
    /// <summary>
    /// This class provides functionality to add a friendship entry to the database.
    /// </summary>
    public class AddFriendToDb
    {
        private readonly ReservoomDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddFriendToDb"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public AddFriendToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new friendship entry to the database based on the provided request.
        /// </summary>
        /// <param name="request">The request containing information about the friendship.</param>
        public void Do(Request request)
        {
            // Check if both StudentId and FriendId are not null before creating a friendship
            if (request.FriendId != null && request.StudentId != null)
            {
                _context.Friends.Add(new FriendsModel
                {
                    StudentId = request.StudentId,
                    FriendId = request.FriendId
                });

                // Save changes to the database
                _context.SaveChanges();
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
            public int? StudentId { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the friend being added.
            /// </summary>
            public int? FriendId { get; set; }
        }
    }
}
