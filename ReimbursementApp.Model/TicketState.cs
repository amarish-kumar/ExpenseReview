using System;
using System.IO;

namespace ReimbursementApp.Model
{
   [Flags()]
    public enum TicketState
    {

        Submitted = 1,

        Pending = 2,

        Approved = 3

    }
}