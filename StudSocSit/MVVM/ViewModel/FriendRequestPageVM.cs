using Commands;
using MVVM.Model;
using MVVM.Model.DataFields;
using StudSocSit.Store;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;

namespace ViewModel;
public class FriendRequestPageVM : ViewModelBase
{
    private List<FriendRequestModel>? friends; 
    public ICommand NavigationToMainPage { get; }
    public ICommand AcceptFriendRequest { get; }

    public FriendRequestPageVM(NavigationStore navigationStore, HttpClient client, StudentModel student, string JWT)
    {
        Friends = new GetFriendRequest(client, JWT).Do();

        NavigationToMainPage = new NavigateToMainPageCommand(navigationStore, client, student, JWT);
        AcceptFriendRequest = new AcceptFriendRequestCommand(client, student, JWT);
    }

    public List<FriendRequestModel>? Friends
    {
        get => friends;
        set
        {
            friends = value;
            OnPropertyChanged(nameof(Friends));
        }
    }
}
