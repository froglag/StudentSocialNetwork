using ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Delete
{
    public class DeleteFriend
    {
        private readonly ReservoomDbContext _context;

        public DeleteFriend(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            
        }
        public class Request
        {
            public int? StudentId { get; set; }
            public int? FriendId { get; set; }
        }
    }
}
