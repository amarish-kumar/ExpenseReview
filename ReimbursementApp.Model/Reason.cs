using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReimbursementApp.Model
{
   public class Reason
    {
        [Key]
        public int ReasonId { get; set; }
        public string Reasoning { get; set; }
        public virtual int EmployeeId { get; set; } 
    }
}
