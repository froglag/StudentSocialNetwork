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

            _context.Message.Add(new MessageModel
            {
                ChatId = request.ChatId,
                AuthorId = request.AuthorId,
                Text = request.Text,
                Timestamp = DateTime.Now
            });
            _context.SaveChanges();
        }

        public class Request
        {
            public string? Text { get; set; }
            public int ChatId { get; set; }
            public int AuthorId { get; set; }

        }
    }
}
