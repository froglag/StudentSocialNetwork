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
    public class AddMessageToDb
    {
        private readonly ReservoomDbContext _context;
        public AddMessageToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            if(request.ChatId != null)
            {
                MessageModel messageModel = new()
                {
                    Text = request.Text,
                    Timestamp = DateTime.Now,
                    ChatId = request.ChatId,
                    AuthorId = request.AuthorId,
                };
                var chatMessages = _context.Chat.First(c => c.ChatId == request.ChatId).Messages;
                if(chatMessages != null )
                {
                    _context.Message.Add(messageModel);
                    chatMessages.Append(messageModel);
                    _context.SaveChanges();
                }
                
            }
        }

        public class Request
        {
            public string? Text { get; set; }

            public int? ChatId { get; set; }

            public int? AuthorId { get; set; }
        }
    }
}
