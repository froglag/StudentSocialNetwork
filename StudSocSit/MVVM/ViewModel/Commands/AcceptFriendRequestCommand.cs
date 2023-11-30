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

/// <summary>
/// This command class handles the acceptance of a friend request, updating the database accordingly.
/// </summary>
public class AcceptFriendRequestCommand : CommandBase
{
    private ReservoomDbContext _context;
    private StudentModel? _student;

    /// <summary>
    /// Initializes a new instance of the <see cref="AcceptFriendRequestCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="student">The student associated with the command.</param>
    public AcceptFriendRequestCommand(ReservoomDbContext context, StudentModel? student)
    {
        _context = context;
        _student = student;
    }

    /// <summary>
    /// Executes the command to accept a friend request.
    /// </summary>
    /// <param name="parameter">The friend identifier to be accepted.</param>
    public override void Execute(object? parameter)
    {
        var friendId = parameter as int?;

        // Check if the student is not null
        if (_student != null)
        {
            // Add the friend to the database as a friend of the student
            new AddFriendToDb(_context).Do(new AddFriendToDb.Request
            {
                FriendId = friendId,
                StudentId = _student.StudentId
            });

            // Add the student as a friend of the accepted friend
            new AddFriendToDb(_context).Do(new AddFriendToDb.Request
            {
                FriendId = _student.StudentId,
                StudentId = friendId
            });

            // Delete the friend request from the database
            new DeleteFriendRequest(_context).Do(friendId);
        }
    }
}