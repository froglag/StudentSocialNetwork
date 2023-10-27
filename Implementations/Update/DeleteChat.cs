using ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Update
{
    public class DeleteChat
    {
        private ReservoomDbContext _context;

        public DeleteChat(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(int chatId)
        {
            var chatIdentity = _context.Chat.First(c => c.ChatId == chatId);
            if (chatIdentity != null)
            {
                _context.Remove(chatIdentity);
                _context.SaveChanges();
            }
        }
    }
}
