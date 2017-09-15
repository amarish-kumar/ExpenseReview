using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace ReimbursementApp.Model
{
   public class Expense
    {
        public string Id { get; set; }
        [Required]
        public DateTime ExpenseDate { get; set; }
        [Required]
        public DateTime SubmitDate { get; set; }
        [Required]
        [StringLength(500)]
        public string ExpenseDetails { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public double TotalAmount { get; set; }
    }
}
