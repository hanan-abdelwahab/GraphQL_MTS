using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  HR.Models;
namespace HR.Logic
{
    public class HRContext
    {
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }
    }
}