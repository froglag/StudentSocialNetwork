using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Commands;
using MVVM.Model.DataFields;
using System.Net.Http;

namespace ViewModel;
public class SearchPageVM : ViewModelBase
{
    private string? userInput;
    private List<SearchInfo> studentsList;

    public ICommand NavigationToMainPage { get; }
    public ICommand NavigationToAccountPage { get; }
    public ICommand MakeFriendRequest { get; }

    public SearchPageVM(NavigationStore navigationStore, HttpClient client, StudentModel? student)
    {
        
        NavigationToMainPage = new NavigateToMainPageCommand(navigationStore, client, student);
        NavigationToAccountPage = new NavigateToAccountPageCommand(navigationStore, client, student);
        MakeFriendRequest = new MakeFriendRequestCommand(navigationStore, client, student);
    }

    public List<SearchInfo> Students
    {
        get
        {
            if (userInput==null)
            {
                return studentsList;
            }
            else
            {
                return studentsList.Where(s => s.Firstname.Contains(userInput)).ToList();
            }

        }
    }

    public string? UserInput
    {
        get =>  userInput;
        set
        {
            userInput = value;
            OnPropertyChanged(nameof(UserInput));
            OnPropertyChanged(nameof(Students));
        }
    }

}
