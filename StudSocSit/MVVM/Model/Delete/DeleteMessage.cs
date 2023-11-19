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
            
        }

        public class Request
        {
            public int ChatId { get; set; }
            public int MessageId { get; set; }
        }
    }
}
