using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Delete
{
    public class DeleteFriendRequest
    {
        private ReservoomDbContext _context;

        public DeleteFriendRequest(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(int? friendId)
        {
            if(friendId != null)
            {
                var friendRequest = _context.FriendRequest.FirstOrDefault(fr => fr.SenderId == friendId);
                if(friendRequest != null)
                {
                    _context.FriendRequest.Remove(friendRequest);
                    _context.SaveChanges();
                }
            }   
        }
    }
}
