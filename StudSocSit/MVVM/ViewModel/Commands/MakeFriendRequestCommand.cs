using MVVM.Model;
using MVVM.Model.DataFields;
using StudSocSit.Store;
using System.Net.Http;
using ViewModel.Commands;


namespace Commands;

/// <summary>
/// This command class handles the creation and execution of a friend request.
/// </summary>
public class MakeFriendRequestCommand : CommandBase
{
    private StudentModel _student;
    private HttpClient _client;
    private NavigationStore _navigationStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="MakeFriendRequestCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="navigationStore">The navigation store for managing navigation within the application.</param>
    /// <param name="student">The student associated with the command.</param>
    public MakeFriendRequestCommand(NavigationStore navigationStore, HttpClient client, StudentModel student)
    {
        _navigationStore = navigationStore;
        _student = student;
        _client = client;
    }

    /// <summary>
    /// Executes the command to create and send a friend request.
    /// </summary>
    /// <param name="parameter">The friend identifier to whom the friend request is sent.</param>
    public override void Execute(object? parameter)
    {
        // Check if the student is not null
        if (_student != null)
        {
            // Create and send a friend request
            new AddFriendRequest(_client).Do(new AddFriendRequest.Request
            {
                SenderId = _student.StudentId,
                ReceiverId = (int)parameter,
            });
        }
    }
}

