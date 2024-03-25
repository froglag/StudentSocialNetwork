using MVVM.Model;
using StudSocSit.Store;
using System.Net.Http;
using System.Windows;
using ViewModel.Commands;
using static ViewModel.LoginVM;

namespace Commands;

/// <summary>
/// This command class handles user authentication and navigation based on the authentication result.
/// </summary>
public class AuthenticationCommand : CommandBase
{
    private UserAuth _userAuth;
    private NavigationStore _navigationStore;
    private HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="navigationStore">The navigation store for managing navigation within the application.</param>
    /// <param name="userAuth">The user authentication information.</param>
    public AuthenticationCommand(NavigationStore navigationStore, HttpClient client, UserAuth userAuth)
    {
        _userAuth = userAuth;
        _navigationStore = navigationStore;
        _client = client;
    }

    /// <summary>
    /// Executes the command to authenticate the user and navigate to the main page if successful.
    /// </summary>
    /// <param name="parameter">The command parameter.</param>
    public override void Execute(object? parameter)
    {
        var JWT = new Login(_client).Do(new Login.Request
        {
            Username = _userAuth.UserName,
            Password = _userAuth.Password
        });
        // Request student information for the authorized user
        var studentInfo = new GetStudentInfo(_client).Do(JWT);

        // If student information is found, navigate to the main page
        if (studentInfo == null)
        {
            MessageBox.Show("Student Doesn't Exist");
        }

        new NavigateToMainPageCommand(_navigationStore, studentInfo).Execute(parameter);

    }
}
