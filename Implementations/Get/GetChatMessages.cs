using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Get
{
    public class GetChatMessages
    {
        private ReservoomDbContext _context;

        public GetChatMessages(ReservoomDbContext context)
        {
            _context = context;
        }

        public Response? Do(int ChatId)
        {
            return _context.Chat
                .Where(c => c.ChatId == ChatId)
                .Select(c => new Response { Messages = c.Messages})
                .First();
        }

        public class Response
        {
            public ICollection<MessageModel> Messages { get; set; }
        }
    }
}
