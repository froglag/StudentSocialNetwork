using Commands;
using StudSocSit.Store;
using System.Windows.Input;

namespace ViewModel;
public class AccountPageVM : ViewModelBase
{

    public ICommand NavigationToSearchPage { get; }
    public ICommand NavigationToMainPage { get; }
    public AccountPageVM(NavigationStore navigationStore)
    {
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
