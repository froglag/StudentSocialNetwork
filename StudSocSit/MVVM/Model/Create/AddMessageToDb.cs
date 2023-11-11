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
            MessageModel messageModel = new()
            {
                Text = request.Text,
                Timestamp = DateTime.Now,
                ChatId = request.ChatId,
                AuthorId = request.AuthorId,
            };
            _context.Message.Add(messageModel);
            _context.Chat.First(c => c.ChatId == request.ChatId).Messages.Append(messageModel);
            _context.SaveChanges();
        }

        public class Request
        {
            public string Text { get; set; }

            public int ChatId { get; set; }

            public int AuthorId { get; set; }
        }
    }
}
