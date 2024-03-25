using MVVM.Model;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    private SighupVM _signup;
    private NavigationStore _navigationStore;
    private HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegistrationSubmitCommand"/> class.
    /// </summary>
    /// <param name="studentInfo">The student registration information to be submitted.</param>
    /// <param name="navigationStore">The navigation store for managing navigation within the application.</param>
    public RegistrationSubmitCommand(SighupVM sighinVM, NavigationStore navigationStore, HttpClient client)
    {
        _signup = sighinVM;
        _navigationStore = navigationStore;
        _client = client;
    }

    /// <summary>
    /// Executes the command to submit student registration information.
    /// </summary>
    /// <param name="parameter">The command parameter.</param>
    public override void Execute(object? parameter)
    {
        // Check if required registration information is provided
        if (_signup.UserName == null || _signup.Password == null || _signup.FirstName == null || _signup.Email == null)
        {
            MessageBox.Show("Not all fields completed");
        }
        else
        {
            // Add student to the database using the provided information
            var addStudent = new AddStudent(_client);
            addStudent.Do(new AddStudent.Request { 
                Email = _signup.Email, 
                FirstName = _signup.FirstName,
                Password = _signup.Password,
                Username = _signup.UserName,
            });

            // Navigate to the login view model after successful registration
            _navigationStore.CurrentViewModel = new LoginVM(_navigationStore, _client);
        }
    }
}

