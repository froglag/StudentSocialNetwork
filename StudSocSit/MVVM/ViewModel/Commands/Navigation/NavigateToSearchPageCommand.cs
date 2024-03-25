using MVVM.Model.DataFields;
using StudSocSit.Store;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToSearchPageCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private readonly StudentModel _student;

    public NavigateToSearchPageCommand(NavigationStore navigation, StudentModel student)
    {
        _navigationStore = navigation;
        _student = student;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new SearchPageVM(_navigationStore, _student);
    }
}
