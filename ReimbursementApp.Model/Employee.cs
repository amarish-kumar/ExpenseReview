using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ReimbursementApp.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(40)]
        public string EmployeeName { get; set; }

    }
}
