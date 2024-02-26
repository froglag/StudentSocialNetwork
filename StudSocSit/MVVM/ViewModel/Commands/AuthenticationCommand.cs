using ApplicationDbContext;
using StudentApplication.Get;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using ViewModel.Commands;
using static ViewModel.LoginVM;

namespace Commands;

/// <summary>
/// This command class handles user authentication and navigation based on the authentication result.
/// </summary>
public class AuthenticationCommand : CommandBase
{
    private ReservoomDbContext _context;
    private NavigationStore _navigationStore;
    private UserAuth _userAuth;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="navigationStore">The navigation store for managing navigation within the application.</param>
    /// <param name="userAuth">The user authentication information.</param>
    public AuthenticationCommand(ReservoomDbContext context, NavigationStore navigationStore, UserAuth userAuth)
    {
        _context = context;
        _navigationStore = navigationStore;
        _userAuth = userAuth;
    }

    /// <summary>
    /// Executes the command to authenticate the user and navigate to the main page if successful.
    /// </summary>
    /// <param name="parameter">The command parameter.</param>
    public override void Execute(object? parameter)
    {
        // Find the user based on the provided username and password
        var user = _context.User.FirstOrDefault(u => u.UserName == _userAuth.UserName && u.Password == _userAuth.Password);

        // If user is found, proceed with authentication
        if (user != null)
        {
            // Request student information for the authorized user
            var studentInfoRequest = new GetAuthorizedStudentInfo.Request { UserName = user.UserName, Password = user.Password };
            var studentInfo = new GetAuthorizedStudentInfo(_context).Do(studentInfoRequest);

            // If student information is found, navigate to the main page
            if (studentInfo != null)
            {
                new NavigateToMainPageCommand(_context, _navigationStore, studentInfo).Execute(parameter);
            }
            else
            {
                MessageBox.Show("Student Doesn't Exist");
            }
        }
        else
        {
            MessageBox.Show("Wrong Login or Password");
        }
    }
}
