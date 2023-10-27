using ApplicationDbContext;
using ApplicationDbContext.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model.Create
{
    public class AddFriendToDb
    {
        private ReservoomDbContext _context;

        public AddFriendToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            var studentIdentity = _context.Student.FirstOrDefault(s => s.StudentId == request.StudentId);
            var friendIdentity = _context.Student.Where(s => s.StudentId == request.FriendId).First();
            if (friendIdentity != null && studentIdentity != null) 
            { 
                studentIdentity.Friends.Add(friendIdentity);
            }
            _context.SaveChanges();
        }

        public class Request
        {
            public int StudentId { get; set; }
            public int FriendId { get; set;}
        }
    }
}
