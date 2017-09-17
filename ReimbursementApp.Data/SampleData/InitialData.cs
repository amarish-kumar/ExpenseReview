using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReimbursementApp.Model;

namespace ReimbursementApp.Data.SampleData
{
   public class InitialData
    {
        private ExpenseReviewDbContext _dbContext;

        public InitialData(ExpenseReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Making sure that database has nothing before seeding
        public void SeedData()
        {
            if (!_dbContext.Expenses.Any())
            {
                //Add New Set
                var expense = new Expense
                {
                    ExpenseDate = "12/09/2017",
                    SubmitDate = "13/09/2017",
                    Amount = 5200,
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            EmployeeId = 93867,
                            EmployeeName = "Rahul Sahay"
                        }
                    },
                    ExpenseDetails = "Random",
                    TotalAmount = 5200

                };
                _dbContext.Expenses.Add(expense);
                _dbContext.Employees.AddRange(expense.Employees);
                _dbContext.SaveChanges();

                var expense1 = new Expense
                {
                    ExpenseDate = "11/09/2017",
                    SubmitDate = "12/09/2017",
                    Amount = 5300,
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            EmployeeId = 93868,
                            EmployeeName = "Kamlesh"
                        }
                    },
                    ExpenseDetails = "Another Expense",
                    TotalAmount = 5300

                };
                _dbContext.Expenses.Add(expense1);
                _dbContext.Employees.AddRange(expense1.Employees);
                _dbContext.SaveChanges();
            }
        }
    }
}
