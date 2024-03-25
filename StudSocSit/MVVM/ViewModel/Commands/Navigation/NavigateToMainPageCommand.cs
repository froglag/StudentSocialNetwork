using MVVM.Model.DataFields;
using StudSocSit.Store;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToMainPageCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private readonly StudentModel _studentInfo;

    public NavigateToMainPageCommand(NavigationStore navigationStore, StudentModel studentInfo)
    {
        _navigationStore = navigationStore;
        _studentInfo = studentInfo;
    }
    public override void Execute(object? parameter)
    {
        if(_studentInfo != null)
        {
            _navigationStore.CurrentViewModel = new MainPageVM(_navigationStore, _studentInfo);
        }
    }
}
