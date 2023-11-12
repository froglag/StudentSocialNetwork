﻿using ApplicationDbContext;
using ApplicationDbContext.Models;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToMainPageCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private ReservoomDbContext _context;
    private StudentModel? _student;

    public NavigateToMainPageCommand(ReservoomDbContext context, NavigationStore navigation, StudentModel? student)
    {
        _context = context;
        _navigationStore = navigation;
        _student = student;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new MainPageVM(_context, _navigationStore, _student);
    }
}
