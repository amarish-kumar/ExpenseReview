using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReimbursementApp.Model
{
   public class Approver
    {
        public int Id { get; set; }
        [Required]
        public int ApproverId { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Remarks { get; set; }
        [Required]
        public string ApprovedDate { get; set; }
        //TODO:Designation may get added, but not required so far.

        public int ExpenseId { get; set; }
    }
}
