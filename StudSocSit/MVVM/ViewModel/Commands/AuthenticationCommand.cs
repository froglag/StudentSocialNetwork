﻿using ApplicationDbContext;
using Model.Get;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using ViewModel.Commands;
using static ViewModel.LoginVM;

namespace Commands;

public class AuthenticationCommand : CommandBase
{
    private ReservoomDbContext _context;
    private NavigationStore? _navigationStore;
    private UserAuth _userAuth;
    public AuthenticationCommand(ReservoomDbContext context, NavigationStore navigationStore, UserAuth userAuth)
    {
        _context = context;
        _navigationStore = navigationStore;
        _userAuth = userAuth;
    }
    public override void Execute(object? parameter)
    {
        try
        {
            var user = _context.User.Where(u => u.UserName == _userAuth.UserName && u.Password == _userAuth.Password).First();
            var studentInfoRequest = new GetAuthorizedStudentInfo.Request { UserName = user.UserName, Password = user.Password };
            var studentInfo = new GetAuthorizedStudentInfo(_context).Do(studentInfoRequest);
            var navigate = new  NavigateToMainPageCommand(_context, _navigationStore, studentInfo);
            navigate.Execute(parameter);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Wronge Login or Password");
        }
    }
}
