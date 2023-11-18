using ApplicationDbContext;
using ApplicationDbContext.Models;
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
        private readonly ReservoomDbContext _context;

        public AddFriendToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            if(request.FriendId != null && request.StudentId != null)
            {
                _context.Friends.Add(new FriendsModel
                {
                    StudentId = request.StudentId,
                    FriendId = request.FriendId
                });
                _context.SaveChanges();
            }
        }

        public class Request
        {
            public int? StudentId { get; set; }
            public int? FriendId { get; set;}
        }
    }
}
