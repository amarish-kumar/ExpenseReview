using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReimbursementApp.Model
{
    /// <summary>
    /// Visa, CAB, Party, OnSite-Kit, etc..
    /// </summary>
   public class ExpenseCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
