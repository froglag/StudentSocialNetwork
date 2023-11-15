using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model.Get
{
    public class GetChatId
    {
        private ReservoomDbContext _context;

        public GetChatId(ReservoomDbContext context)
        {
            _context = context;
        }

        public int? Do(ICollection<StudentModel>? participants)
        {
            return _context.Chat.Where(c => c.Participants == participants).First().ChatId;
        }
    }
}
