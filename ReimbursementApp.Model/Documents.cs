using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReimbursementApp.Model
{
   public class Documents
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string DocName { get; set; }
        public int ExpenseId { get; set; }

    }
}
