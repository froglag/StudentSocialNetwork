using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel;
public class AccountSettingVM : ViewModelBase
{
    private string name { get; set; }
    private string surname { get; set; }
    [EmailAddress]
    private string email { get; set; }
    [Phone]
    private int phonenumber { get; set; }
    private string facultyName { get; set; }
    private string specialization { get; set; }

    public AccountSettingVM()
    {
        
    }

    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Surname
    {
        get => surname;
        set
        {
            surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }

    public string Email
    {
        get => email;
        set
        {
            email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public int Phonenumber
    {
        get => phonenumber;
        set
        {
            phonenumber = value;
            OnPropertyChanged(nameof(Phonenumber));
        }
    }

    public string FacultyName
    {
        get => facultyName;
        set
        {
            facultyName = value;
            OnPropertyChanged(nameof(FacultyName));
        }
    }

    public string Specialization
    {
        get => specialization;
        set
        {
            specialization = value;
            OnPropertyChanged(nameof(Specialization));
        }
    }
}
