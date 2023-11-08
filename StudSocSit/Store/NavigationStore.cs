using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace StudSocSit.Store;

public class NavigationStore
{
    private ViewModelBase? _currentViewModel;
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set => _currentViewModel = value;
    }
}
