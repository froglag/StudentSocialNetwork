using StudSocSit.Store;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToMainPageCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private StudentModel? _student;
    private object studentInfo;

    public NavigateToMainPageCommand(NavigationStore navigationStore, StudentModel? student)
    {
        _navigationStore = navigationStore;
        _student = student;
    }
    public override void Execute(object? parameter)
    {
        if(_student!=null)
        {
            _navigationStore.CurrentViewModel = new MainPageVM(_navigationStore, _student);
        }
    }
}
