using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Get
{
    /// <summary>
    /// This class provides functionality to retrieve messages for a specific chat from the database.
    /// </summary>
    public class GetChatMessages
    {
        private readonly ReservoomDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetChatMessages"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public GetChatMessages(ReservoomDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves messages for a specific chat from the database based on the provided chat identifier.
        /// </summary>
        /// <param name="chatId">The identifier of the chat for which messages are to be retrieved.</param>
        /// <returns>Returns a list of <see cref="MessageModel"/> for the specified chat; returns null if the chat or messages are not found.</returns>
        public List<MessageModel>? Do(int chatId)
        {
            // Retrieve messages for the specified chat
            return _context.Message.Where(m => m.ChatId == chatId).ToList();
        }
    }
}
