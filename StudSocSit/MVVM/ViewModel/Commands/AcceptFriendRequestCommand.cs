using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Create;
using Model.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace Commands;
public class AcceptFriendRequestCommand : CommandBase
{
    private ReservoomDbContext _context;
    private StudentModel? _student;

    public AcceptFriendRequestCommand(ReservoomDbContext context, StudentModel? student)
    {
        _context = context;
        _student = student;
    }
    public override void Execute(object? parameter)
    {
        var friendId = parameter as int?;
        if(_student != null)
        {
            new AddFriendToDb(_context).Do(new AddFriendToDb.Request
            {
                FriendId = friendId,
                StudentId = _student.StudentId
            });

            new AddFriendToDb(_context).Do(new AddFriendToDb.Request
            {
                FriendId = _student.StudentId,
                StudentId = friendId
            });

            new DeleteFriendRequest(_context).Do(friendId);
        }
    }
}
