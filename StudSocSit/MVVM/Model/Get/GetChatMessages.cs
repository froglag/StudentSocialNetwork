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
        private readonly ReservoomDbContext _context;

        public GetChatMessages(ReservoomDbContext context)
        {
            _context = context;
        }

        public List<MessageModel>? Do(int chatId)
        {
            return _context.Message.Where(m => m.ChatId == chatId).ToList();
        }

    }
}
