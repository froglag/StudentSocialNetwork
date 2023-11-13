using ApplicationDbContext;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Commands;
using ApplicationDbContext.Models;

namespace ViewModel;
public class SearchPageVM : ViewModelBase
{
    private ReservoomDbContext _context;
    private NavigationStore _navigationStore;
    private StudentModel? _student;
    private string? userInput;
    private List<StudentModel> studentsList;

    public ICommand NavigationToMainPage { get; }
    public ICommand NavigationToAccountPage { get; }

    public SearchPageVM(ReservoomDbContext context, NavigationStore navigationStore, StudentModel? student)
    {
        studentsList = context.Student.ToList();
        studentsList.Remove(student);
        _navigationStore = navigationStore;
        _student = student;
        NavigationToMainPage = new NavigateToMainPageCommand(context, navigationStore, student);
        NavigationToAccountPage = new NavigateToAccountPageCommand(context, navigationStore, student);
    }

    public List<StudentModel> Students
    {
        get
        {
            if (userInput==null)
            {
                return studentsList;
            }
            else
            {
                return studentsList.Where(s => s.FirstName.Contains(userInput)).ToList();
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
