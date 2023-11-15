using ApplicationDbContext;
using ApplicationDbContext.Models;
using SQLitePCL;
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
            if(_context.FriendRequest.First(fr => fr.StudentId == request.StudentId && fr.FriendId == request.FriendId) == null)
            {
                _context.FriendRequest.Add(new FriendRequestModel
                {
                    FriendId = request.FriendId,
                    StudentId = request.StudentId
                });
                _context.SaveChanges();
            }

            var friendRequest = _context.FriendRequest.First(fr => fr.StudentId == request.StudentId && fr.FriendId == request.FriendId);
            var studentFriendRequestCollection = _context.Student.Where(s => s.StudentId == request.StudentId).First().FriendRequests;
            if (studentFriendRequestCollection != null)
            {
                if(studentFriendRequestCollection.First(sf => sf.StudentId == request.StudentId && sf.FriendId == request.FriendId) == null)
                {
                    studentFriendRequestCollection.Add(friendRequest);
                }
            }
            else
            {
                studentFriendRequestCollection = new List<FriendRequestModel>() { friendRequest};
            }
           
        }

        public class Request
        {
            public int? StudentId { get; set; }
            public int? FriendId { get; set; }
        }
    }
}
