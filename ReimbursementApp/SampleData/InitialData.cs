using System.Linq;
using ReimbursementApp.DbContext;
using ReimbursementApp.Model;

namespace ReimbursementApp.SampleData
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
                    Employees = new Employee
                    {

                        EmployeeId = 93888,
                        EmployeeName = "Shyam Sinha"

                    },
                    ExpenseDetails = "Random",
                    TotalAmount = 5200,
                    Approvers = new Approver
                    {

                        ApproverId = 1234,
                        ApprovedDate = "13/09/2017",
                        Name = "Dhaval",
                        Remarks = "Approved"

                    },
                    Status = new TicketStatus { State = TicketState.Approved}

                };
                _dbContext.Expenses.Add(expense);
                _dbContext.Employees.AddRange(expense.Employees);
                _dbContext.Approvers.AddRange(expense.Approvers);
                _dbContext.SaveChanges();

                var expense1 = new Expense
                {
                    ExpenseDate = "11/09/2017",
                    SubmitDate = "12/09/2017",
                    Amount = 5300,
                    Employees = new Employee
                    {
                        EmployeeId = 93868,
                        EmployeeName = "Kamlesh"

                    },
                    ExpenseDetails = "Another Expense",
                    TotalAmount = 5300,
                    Approvers = new Approver
                    {
                        ApproverId = 2345,
                        ApprovedDate = "13/09/2017",
                        Name = "Deepak",
                        Remarks = "nothing"

                    },
                    Status = new TicketStatus { State = TicketState.Pending }

                };
                _dbContext.Expenses.Add(expense1);
                _dbContext.Employees.AddRange(expense1.Employees);
                _dbContext.Approvers.AddRange(expense1.Approvers);
                _dbContext.SaveChanges();

                var expense2 = new Expense
                {
                    ExpenseDate = "10/09/2017",
                    SubmitDate = "11/09/2017",
                    Amount = 5400,
                    Employees = new Employee
                    {
                        EmployeeId = 93869,
                        EmployeeName = "John"

                    },
                    ExpenseDetails = "Misel",
                    TotalAmount = 5400,
                    Approvers = new Approver
                    {
                        ApproverId = 3456,
                        ApprovedDate = "13/09/2017",
                        Name = "Mrinal",
                        Remarks = "Reviewing"

                    },
                    Status = new TicketStatus { State = TicketState.Submitted }

                };
                _dbContext.Expenses.Add(expense2);
                _dbContext.Employees.AddRange(expense2.Employees);
                _dbContext.Approvers.AddRange(expense2.Approvers);
                _dbContext.SaveChanges();
            }
        }
    }
}
