using System;
using ReimbursementApp.Model;

namespace ReimbursementApp.Helpers
{
    public static class EnumHelper
    {
        public static TicketState GetMyEnum(this string title)
        {
            TicketState st;
            Enum.TryParse(title, out st);
            return st;
        }

    }
}