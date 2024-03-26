using MVVM.Model;
using MVVM.Model.DataFields;
using System.Net.Http;
using ViewModel.Commands;

namespace Commands;

/// <summary>
/// This command class handles the update of user information in the database.
/// </summary>
public class UpdateUserInfoCommand : CommandBase
{
    private StudentModel _student;
    private HttpClient _client;
    private string _JWT;


    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateUserInfoCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="student">The student associated with the command.</param>
    public UpdateUserInfoCommand(HttpClient client, StudentModel student, string JWT)
    {
        _student = student;
        _client = client;
        _JWT = JWT;
    }

    /// <summary>
    /// Executes the command to update user information in the database.
    /// </summary>
    /// <param name="parameter">The command parameter.</param>
    public override void Execute(object? parameter)
    {
        // Update user information in the database using the provided student information
        new UpdateUserInfo(_client, _JWT).Do(new UpdateUserInfo.Request
        {
            FirstName = _student.FirstName,
            LastName = _student.LastName,
            Email = _student.Email,
            FacultyName = _student.FacultyName,
            PhoneNumber = _student.PhoneNumber,
            Specialization = _student.Specialization,
        });
    }
}

