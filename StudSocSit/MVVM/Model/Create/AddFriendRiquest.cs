using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Create
{
    public class AddFriendRiquest
    {
        private ReservoomDbContext _context;

        public AddFriendRiquest(ReservoomDbContext context)
        {
            _context = context;
        }
        public void Do(Request request)
        {
            var friendRequest = _context.FriendRequest.FirstOrDefault(fr => fr.SenderId == request.SenderId && fr.ReceiverId == request.ReceiverId);
            var friend = _context.Friends.FirstOrDefault(f => f.StudentId == request.ReceiverId && f.FriendId == request.SenderId);

            if (friendRequest == null && friend == null)
            {
                _context.FriendRequest.Add(new FriendRequestModel
                {
                    ReceiverId = request.ReceiverId,
                    SenderId = request.SenderId
                });
                _context.SaveChanges();
            }
        }

        public class Request
        {
            public int? SenderId { get; set; }
            public int? ReceiverId { get; set; }
        }
    }
}
