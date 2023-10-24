using ApplicationDbContext;
using ApplicationDbContext.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
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
            var friend = new FriendModel
            {
                FriendId = request.FriendId,
                StudentId = request.StudentId,
            };
            _context.Friend.Add(friend);

            _context.Student.FirstOrDefault(s => s.StudentId == request.StudentId).Friends.Add(friend);

            _context.SaveChanges();
        }
        public class Request
        {
            public int FriendId { get; set; }
            public int StudentId { get; set; }
        }
    }
}
