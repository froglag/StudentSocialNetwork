using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentApplication.Create
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
        public async Task<Response> Do(Request request)
        {
            MessageModel message = new MessageModel()
            {
                ChatId = request.ChatId,
                AuthorId = request.AuthorId,
                Text = request.Text,
                Timestamp = DateTime.Now
            };
            _context.Message.Add(message);

            // Save changes to the database
            await _context.SaveChangesAsync();
            return new Response()
            {
                MessageId = message.MessageId,
                ChatId = message.ChatId,
                AuthorId = message.AuthorId,
                Text = message.Text,
                Timestamp = message.Timestamp
            };
        }

        /// <summary>
        /// Represents the request format for adding a new message to a chat.
        /// </summary>
        public class Request
        {
            /// <summary>
            /// Gets or sets the text content of the message.
            /// </summary>
            public required string Text { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the chat to which the message belongs.
            /// </summary>
            public int ChatId { get; set; }

            /// <summary>
            /// Gets or sets the identifier of the author of the message.
            /// </summary>
            public int AuthorId { get; set; }
        }

        public class Response
        {
            public int MessageId { get; set; }
            public required string Text { get; set; }
            public int ChatId { get; set; }
            public int AuthorId { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }
}
