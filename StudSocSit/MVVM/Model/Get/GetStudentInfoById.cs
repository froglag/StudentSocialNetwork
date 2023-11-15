using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Model.Get
{
    public class GetStudentInfoById
    {
        private readonly ReservoomDbContext _context;

        public GetStudentInfoById(ReservoomDbContext context)
        {
            _context = context;
        }

        public StudentModel? Do(int? studentId)
        {
            if(studentId != null)
            {
                try
                {
                    return _context.Student
                    .Where(s => s.StudentId == studentId)
                    .First();
                }catch(Exception)
                {
                    return null;
                }
               

            }else return null;
        }

    }
}
