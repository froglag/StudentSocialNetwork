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
public class UpdateUserInfoCommand : CommandBase
{
    private StudentModel? _student;
    private ReservoomDbContext _context;
    public UpdateUserInfoCommand(ReservoomDbContext context ,StudentModel? student)
    {
        _context = context;
        _student = student;
    }
    public override void Execute(object? parameter)
    {
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
