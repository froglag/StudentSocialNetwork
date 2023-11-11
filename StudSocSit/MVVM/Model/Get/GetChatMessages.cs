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

        public IEnumerable<MessageModel>? Do(ICollection<StudentModel> participans)
        {
            return _context.Chat
                .Where(c => c.Participants == participans)
                .Select(c => c.Messages)
                .First();
        }

    }
}
