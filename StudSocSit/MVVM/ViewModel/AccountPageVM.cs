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

namespace ViewModel;
public class AccountPageVM : ViewModelBase
{
    private StudentModel _friend;

    public ICommand NavigationToSearchPage { get; }
    public ICommand NavigationToMainPage { get; }
    public AccountPageVM(ReservoomDbContext context, NavigationStore navigationStore, StudentModel? student, StudentModel friend)
    {
        _friend = friend;
        NavigationToSearchPage = new NavigateToSearchPageCommand(context, navigationStore, student);
        NavigationToMainPage = new NavigateToMainPageCommand(context, navigationStore, student);
    }

    public StudentModel? Friend
    {
        get => _friend;
        set 
        {
            _friend = value; 
            OnPropertyChanged(nameof(Friend));
        }
    }
}
