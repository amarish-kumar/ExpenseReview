using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementApp.ViewModels
{
    public class ExpenseViewModel
    {
        public string EmployeeName { get; set; }
        public string ApproverName { get; set; }
        public string SubmitDate { get; set; }
        public string ApprovedDate { get; set; }
        public string TicketStatus { get; set; }
        public int ExpenseId { get; set; }

    }
}
