using ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Delete
{
    public class DeleteMessage
    {
        private readonly ReservoomDbContext _context;

        public DeleteMessage(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            var chatIdentity = _context.Chat.Where(c => c.ChatId == request.ChatId).First();
            var messageIdentity = chatIdentity.Messages.Where(m => m.MessageId == request.MessageId).First();

            chatIdentity.Messages.Remove(messageIdentity);
            _context.SaveChanges();
        }

        public class Request
        {
            public int ChatId { get; set; }
            public int MessageId { get; set; }
        }
    }
}
