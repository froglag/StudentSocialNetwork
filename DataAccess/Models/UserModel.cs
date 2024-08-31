using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class UserModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string University { get; set; }
    public string Faculty { get; set; }
    public string Specialization { get; set; }
    public string Email { get; set; }
}
