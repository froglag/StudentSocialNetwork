using ViewModel;
using static ViewModel.MainPageVM;
using ViewModel.Commands;
using System.Net.Http;
using MVVM.Model;

namespace Commands;

/// <summary>
/// This command class handles the retrieval of chat messages and updates the ViewModel accordingly.
/// </summary>
public class GetChatMessagesCommand : CommandBase
{
    private readonly HttpClient _client;
    private readonly MainPageVM _mainPageVM;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetChatMessagesCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="mainPageVM">The ViewModel associated with the main page.</param>
    public GetChatMessagesCommand(HttpClient client, MainPageVM mainPageVM)
    {
        _client = client;
        _mainPageVM = mainPageVM;
    }

    /// <summary>
    /// Executes the command to retrieve chat messages and update the ViewModel.
    /// </summary>
    /// <param name="parameter">The friend identifier associated with the chat.</param>
    public override void Execute(object? parameter)
    {
        var getResponse = new GetChatMessage(_client).Do(parameter.ToString());
        _mainPageVM.FriendId = (int)parameter;
        getResponse.ForEach(m =>
        {
            _mainPageVM.MessageContent.Add(new MessageCollection
            {
                Messages = m,
                StudentId = _mainPageVM.StudentInfo.StudentId,
                FriendId = (int)parameter,
            });
        });
    }
}

