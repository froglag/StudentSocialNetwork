using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Create;
public class AddChatToDb
{
    private ReservoomDbContext _context;

    public AddChatToDb(ReservoomDbContext context)
    {
        _context = context;
    }

    public void Do(Request request)
    {
        _context.Chat.Add(new ChatModel
        {
            FirstStudentId = request.FirstStudentId,
            SecondStudentId = request.SecondStudentId
        });
        _context.SaveChanges();
    }

    public class Request
    {
        public int FirstStudentId { get; set; }
        public int SecondStudentId { get; set; }
    }
}
