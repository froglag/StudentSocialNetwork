using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model.Create
{
    /// <summary>
    /// This class provides functionality to add a new message to a chat in the database.
    /// </summary>
    public class AddMessageToDb
    {
        private readonly ReservoomDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddMessageToDb"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public AddMessageToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new message to a chat in the database based on the provided request.
        /// </summary>
        /// <param name="request">The request containing information about the message.</param>
        public void Do(Request request)
        {
            _context.Message.Add(new MessageModel
            {
                ChatId = request.ChatId,
                AuthorId = request.AuthorId,
                Text = request.Text,
                Timestamp = DateTime.Now
            });

            // Save changes to the database
            _context.SaveChanges();
        }

        /// <summary>
        /// Represents the request format for adding a new message to a chat.
        /// </summary>
        public class Request
        {
            /// <summary>
            /// Gets or sets the text content of the message.
            /// </summary>
            public string? Text { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the chat to which the message belongs.
            /// </summary>
            public int ChatId { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the author of the message.
            /// </summary>
            public int AuthorId { get; set; }
        }
    }
}
