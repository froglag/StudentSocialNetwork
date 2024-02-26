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
using StudentApplication.Get;

namespace ViewModel;
public class FriendRequestPageVM : ViewModelBase
{
    private ICollection<StudentModel>? friends; 
    public ICommand NavigationToMainPage { get; }
    public ICommand AcceptFriendRequest { get; }

    public FriendRequestPageVM(ReservoomDbContext context, NavigationStore navigationStore, StudentModel student)
    {
        Friends = new List<StudentModel>();
        var friendRequest = context.FriendRequest.Where(f => f.ReceiverId == student.StudentId).ToList();
        if (student != null && friendRequest != null)
        {
            
            foreach (var friendId in friendRequest)
            {
                var info = new GetStudentInfoById(context).Do(friendId.SenderId);
                if (info != null)
                {
                    Friends.Add(info);
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
