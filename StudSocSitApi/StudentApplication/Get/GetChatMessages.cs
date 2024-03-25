using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.Get
{
    /// <summary>
    /// This class provides functionality to retrieve messages for a specific chat from the database.
    /// </summary>
    public class GetChatMessages
    {
        private readonly ReservoomDbContext _context;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetChatMessages"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public GetChatMessages(ReservoomDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves messages for a specific chat from the database based on the provided chat identifier.
        /// </summary>
        /// <param name="chatId">The identifier of the chat for which messages are to be retrieved.</param>
        /// <returns>Returns a list of <see cref="MessageModel"/> for the specified chat; returns null if the chat or messages are not found.</returns>
        public async Task<IResult> Do(int chatId)
        {
            var messageList = await _context.Message.Where(m => m.ChatId == chatId).ToListAsync();

            if(messageList is null) 
            {
                _logger.LogError("Chat messages not found");
                return Results.NotFound("Chat messages not found");
            }

            List<Response> response = new List<Response>();

            messageList.ForEach(m =>
            {
                response.Add(new Response 
                {
                    Text = m.Text,
                    AuthorId = m.AuthorId,
                    Timestamp = m.Timestamp,
                });
            });
            _logger.LogInformation("Messages succesfully retrieved");
            return Results.Json(response);
        }

        public class Response
        {
            public required string Text { get; set; }
            public DateTime Timestamp { get; set; }

            public int AuthorId { get; set; }
        }
    }
}
