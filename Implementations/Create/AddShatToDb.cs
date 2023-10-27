using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Create
{
    public class AddShatToDb
    {
        private ReservoomDbContext _context;
        public AddShatToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            ChatModel chatModel = new ChatModel
            {
                Participants = request.Participants,
            };
            _context.Chat.Add(chatModel);
            _context.SaveChanges();
        }

        public class Request
        {
            public ICollection<StudentModel> Participants { get; set; }
        }
    }
}
