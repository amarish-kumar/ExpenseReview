using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReimbursementApp.Model
{
   public class Approver
    {
        public int Id { get; set; }
        public int ApproverId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public string ApprovedDate { get; set; }
        //TODO:Designation may get added, but not required so far.
        public int ExpenseId { get; set; }
    }
}
