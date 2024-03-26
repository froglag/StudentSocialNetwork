using MVVM.Model;
using MVVM.Model.DataFields;
using System.Net.Http;
using ViewModel.Commands;

namespace Commands;

/// <summary>
/// This command class handles the acceptance of a friend request, updating the database accordingly.
/// </summary>
public class AcceptFriendRequestCommand : CommandBase
{
    private StudentModel _student;
    private HttpClient _client;
    private string _JWT;

    /// <summary>
    /// Initializes a new instance of the <see cref="AcceptFriendRequestCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="student">The student associated with the command.</param>
    public AcceptFriendRequestCommand(HttpClient client, StudentModel student, string JWT)
    {
        _student = student;
        _client = client;
        _JWT = JWT;
    }

    /// <summary>
    /// Executes the command to accept a friend request.
    /// </summary>
    /// <param name="parameter">The friend identifier to be accepted.</param>
    public override void Execute(object? parameter)
    {
        var friendId = (int)parameter;

        new AddFriend(_client, _JWT).Do(friendId);

    }
}