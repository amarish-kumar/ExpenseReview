using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ReimbursementApp.Model
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(40)]
        public string EmployeeName { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }

        public Employee()
        {
            Expenses= new Collection<Expense>();
        }
    }
}
