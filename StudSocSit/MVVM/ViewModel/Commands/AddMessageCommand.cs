using MVVM.Model;
using System.Linq;
using System.Net.Http;
using ViewModel;
using ViewModel.Commands;

namespace Commands;

/// <summary>
/// This command class handles the addition of a message to a chat, updating the database accordingly.
/// </summary>
public class AddMessageCommand : CommandBase
{
    private readonly MainPageVM _mainPageVM;
    private readonly HttpClient _client;
    private readonly string _JWT;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddMessageCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="mainPageVM">The ViewModel associated with the main page.</param>
    public AddMessageCommand(MainPageVM mainPageVM, HttpClient client, string JWT)
    {
        _mainPageVM = mainPageVM;
        _client = client;
        _JWT = JWT;
    }

    /// <summary>
    /// Executes the command to add a message to a chat.
    /// </summary>
    /// <param name="parameter">The friend identifier associated with the chat.</param>
    public override void Execute(object? parameter)
    {
        var response = new AddMessage(_client, _JWT).Do(parameter.ToString());

        // Execute a command to retrieve and update chat messages
        new GetChatMessagesCommand(_client, _mainPageVM, _JWT).Execute(_mainPageVM.FriendId);

    }
}

