using System;
using System.Collections.Generic;
using System.Text;

namespace ReimbursementApp.Model
{
   public class TicketStatus
    {
        public int Id { get; set; }
        public virtual TicketState State { get; set; }
    }
}
