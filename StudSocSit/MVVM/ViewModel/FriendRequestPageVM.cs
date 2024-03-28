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

    public FriendRequestPageVM(NavigationStore navigationStore, HttpClient client, StudentModel student)
    {
        Friends = new GetFriendRequest(client).Do();

        NavigationToMainPage = new NavigateToMainPageCommand(navigationStore, client, student);
        AcceptFriendRequest = new AcceptFriendRequestCommand(client, student);
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
