﻿using Commands;
using MVVM.Model.DataFields;
using StudSocSit.Store;
using System.Net.Http;
using System.Windows.Input;

namespace ViewModel;
public class AccountPageVM : ViewModelBase
{
    private StudentModel? _friend;

    public ICommand NavigationToSearchPage { get; }
    public ICommand NavigationToMainPage { get; }
    public AccountPageVM(NavigationStore navigation, HttpClient client, StudentModel student, StudentModel friend)
    {
        _friend = friend;
        NavigationToSearchPage = new NavigateToSearchPageCommand(navigation, client, student);
        NavigationToMainPage = new NavigateToMainPageCommand(navigation, client, student);
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
