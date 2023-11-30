using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Create;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using ViewModel.Commands;

namespace Commands;

/// <summary>
/// This command class handles the submission of student registration information.
/// </summary>
public class RegistrationSubmitCommand : CommandBase
{
    private AddStudentToDb.Request? _studentInfo;
    private ReservoomDbContext _context;
    private NavigationStore _navigationStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegistrationSubmitCommand"/> class.
    /// </summary>
    /// <param name="studentInfo">The student registration information to be submitted.</param>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="navigationStore">The navigation store for managing navigation within the application.</param>
    public RegistrationSubmitCommand(AddStudentToDb.Request? studentInfo, ReservoomDbContext context, NavigationStore navigationStore)
    {
        _studentInfo = studentInfo;
        _context = context;
        _navigationStore = navigationStore;
    }

    /// <summary>
    /// Executes the command to submit student registration information.
    /// </summary>
    /// <param name="parameter">The command parameter.</param>
    public override void Execute(object? parameter)
    {
        // Check if required registration information is provided
        if (_studentInfo.UserName == null || _studentInfo.Password == null || _studentInfo.FirstName == null)
        {
            MessageBox.Show("Not all fields completed");
        }
        else
        {
            // Add student to the database using the provided information
            var addStudent = new AddStudentToDb(_context);
            addStudent.Do(_studentInfo);

            // Navigate to the login view model after successful registration
            _navigationStore.CurrentViewModel = new LoginVM(_context, _navigationStore);
        }
    }
}

