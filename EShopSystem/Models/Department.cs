using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool DepartmentIsActive { get; set; }

        public virtual ICollection <Employee> Employees { get; set; }
    }
}