using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class SearchEmployee_Result
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfileImage { get; set; }
        public string FbProfileLink { get; set; }
        public string TwitterProfileLink { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int SubDepartmentId { get; set; }
        public string SubDepartmentName { get; set; }
    }
}
