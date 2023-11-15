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
            try
            {
                var requestCollection = _context.Student.Where(s => s.FriendRequests.First(fr => fr.FriendId == friendId).FriendId == friendId).First().FriendRequests;
                var request = requestCollection.First(fr => fr.FriendId == friendId);
                requestCollection.Remove(request);
                _context.SaveChanges();
            }
            finally
            {

            }
            
        }
    }
}
