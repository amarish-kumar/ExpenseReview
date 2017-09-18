using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReimbursementApp.Model;

namespace ReimbursementApp.ViewModels
{
    public class EmployeeViewModel
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string AlternateNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ReportingManager { get; set; }
    }
}
