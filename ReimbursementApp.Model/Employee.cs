using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ReimbursementApp.Model
{
    //TODO:- Sign info will present below screen. This is one time activity.
    public class Employee
    {
        public int Id { get; set; }
        //TODO on Expense page, EMP_Id and Approver name will get auto populated
        public int EmployeeId { get; set; }
        //This will get populated via windows login
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

        //TODO:- Need to think on this relationship
      //  public virtual Approver ReportingManager { get; set; }
        public string ReportingManager { get; set; }
      

     }
}
