using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReimbursementApp.Model
{
    /// <summary>
    /// Visa, CAB, Party, OnSite-Kit, etc..
    /// </summary>
   public class ExpenseCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
