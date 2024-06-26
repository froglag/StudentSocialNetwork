﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model.DataFields;

public class StudentModel
{
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? FacultyName { get; set; }
    public string? Specialization { get; set; }
    public string? PhoneNumber { get; set;}
}
