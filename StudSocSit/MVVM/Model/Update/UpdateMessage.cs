using ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model.Update
{
    public class UpdateMessage
    {
        private readonly ReservoomDbContext _context;

        public UpdateMessage(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            var messageIdentity = _context.Message.First(m => m.MessageId == request.MessageId);
            if(messageIdentity != null)
            {
                messageIdentity.Text = request.Text;
                _context.SaveChanges();
            }
        }

        public class Request
        {
            public int MessageId { get; set; }
            public string Text { get; set; }
        }
    }
}
