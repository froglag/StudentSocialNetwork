using ApplicationDbContext;
using ApplicationDbContext.Models;
using Commands;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.Get;

namespace ViewModel;
public class FriendRequestPageVM : ViewModelBase
{
    private ICollection<StudentModel>? friends; 
    public ICommand NavigationToMainPage { get; }
    public ICommand AcceptFriendRequest { get; }

    public FriendRequestPageVM(ReservoomDbContext context, NavigationStore navigationStore, StudentModel student)
    {
        if(student != null && student.FriendRequests != null)
        {
            foreach (var friendId in student.FriendRequests)
            {
                var info = new GetStudentInfoById(context).Do(friendId.FriendId);
                if (info != null && friends != null)
                {
                    friends.Add(info);
                }
            }
        }

        NavigationToMainPage = new NavigateToMainPageCommand(context, navigationStore, student);
        AcceptFriendRequest = new AcceptFriendRequestCommand(context, student);
    }

    public ICollection<StudentModel>? Friends
    {
        get => friends;
        set
        {
            friends = value;
            OnPropertyChanged(nameof(Friends));
        }
    }
}
