using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public virtual ICollection<SubDepartment> SubDepartments { get; set; }
    }
}
