using System;
using System.IO;

namespace ReimbursementApp.Model
{
   [Flags()]
    public enum TicketState
    {

        //Approval --> This is for offline, 
        //Submitted --> Pending for approval, Next-->AdminCheck-->FinanceCheck Status (Processed,Pending with reason)
        //Need to create two flows for admin and Bills
        Submitted = 1,

        PendingWithManager = 2, //either from admin, finance, manager, reason also required, different pendings

        ApprovedFromManager = 3, //different approvals with reason

        PendingWithAdmin = 4,

        ApprovedFromAdmin = 5,

        PendingWithFinanace = 6,

        ApprovedFromFinance = 7
        
       //Expense categories. Let it open, so that admin can add new category.
        //Categories won't have enum types as this will be generic 
    }
}