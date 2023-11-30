using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace Commands;

/// <summary>
/// This command class handles the update of user information in the database.
/// </summary>
public class UpdateUserInfoCommand : CommandBase
{
    private StudentModel? _student;
    private ReservoomDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateUserInfoCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="student">The student associated with the command.</param>
    public UpdateUserInfoCommand(ReservoomDbContext context, StudentModel? student)
    {
        _context = context;
        _student = student;
    }

    /// <summary>
    /// Executes the command to update user information in the database.
    /// </summary>
    /// <param name="parameter">The command parameter.</param>
    public override void Execute(object? parameter)
    {
        // Update user information in the database using the provided student information
        new UpdateStudentInfo(_context).Do(new UpdateStudentInfo.Request
        {
            StudentId = _student.StudentId,
            FirstName = _student.FirstName,
            LastName = _student.LastName,
            Email = _student.Email,
            FacultyName = _student.FacultyName,
            PhoneNumber = _student.PhoneNumber,
            Specialization = _student.Specialization
        });
    }
}

