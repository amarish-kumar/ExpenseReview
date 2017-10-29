using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReimbursementApp.Model
{
   public class ApproverList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApproverId { get; set; }
        public string Name { get; set; }
        
    }
}
