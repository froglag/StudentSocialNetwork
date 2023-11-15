using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Create;
using Model.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace Commands;
public class AddMessageCommand : CommandBase
{
    private ReservoomDbContext _context;
    private StudentModel? _student;
    private int? _friendId;
    private ICollection<StudentModel>? participants;
    public AddMessageCommand(ReservoomDbContext context, StudentModel? student, int? friendId)
    {
        _context = context;
        _student = student;
        _friendId = friendId;
       
    }
    public override void Execute(object? parameter)
    {
        var text = parameter as string;
        var friend = new GetStudentInfoById(_context).Do(_friendId);

        if (participants != null && friend != null && _student != null)
        {
            participants.Add(_student);
            participants.Add(friend);
        }
       
        if (new GetChatId(_context).Do(participants) != null && _student != null)
        {
            new AddMessageToDb(_context).Do(new AddMessageToDb.Request
            {
                AuthorId = _student.StudentId,
                Text = text,
                ChatId = new GetChatId(_context).Do(participants)
            });
            _context.SaveChanges();
        }
        else if(participants != null && _student != null)
        {
            new AddChatToDb(_context).Do(new AddChatToDb.Request
            {
                Participants = participants
            });
            _context.SaveChanges();
            new AddMessageToDb(_context).Do(new AddMessageToDb.Request
            {
                AuthorId = _student.StudentId,
                Text = text,
                ChatId = new GetChatId(_context).Do(participants)
            });
            _context.SaveChanges();
        }
    }
}
