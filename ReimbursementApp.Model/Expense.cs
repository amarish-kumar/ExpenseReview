using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace ReimbursementApp.Model
{
   public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string ExpenseDate { get; set; }
        [Required]
        public string SubmitDate { get; set; }
        [Required]
        [StringLength(500)]
        public string ExpenseDetails { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public double TotalAmount { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Approver> Approvers { get; set; }

        public Expense()
        {
            Employees= new Collection<Employee>();
            Approvers= new Collection<Approver>();
        }
        
    }
}
