using ApplicationDbContext;
using ApplicationDbContext.Models;
using Create;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace Commands;
public class MakeFriendRequestCommand : CommandBase
{
    private ReservoomDbContext _context;
    private StudentModel? _student;
    private NavigationStore _navigationStore;
    public MakeFriendRequestCommand(ReservoomDbContext context, NavigationStore navigationStore, StudentModel? student)
    {
        _context = context;
        _navigationStore = navigationStore;
        _student = student;
    }
    public override void Execute(object? parameter)
    {
        if (_student != null)
        {
            var friendId = parameter as int?;

            new AddFriendRiquest(_context).Do(new AddFriendRiquest.Request
            {
                StudentId = _student.StudentId,
                FriendId = friendId
            });
        }
    }
}
