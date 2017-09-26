using System;
using System.Collections.Generic;
using System.Text;
using ReimbursementApp.Model;

namespace ReimbursementApp.Data.Contracts
{
    public interface IExpenseReviewUOW
    {
        /// <summary>
        /// This is extendable pattern. If required, more things can be added in future
        /// </summary>
        void Commit();
        IRepository<Expense> Expenses { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Approver> Approvers { get; }
        IRepository<ExpenseCategory> ExpCategories { get; }
        IRepository<ExpenseCategorySet> ExpenseCategorySets { get; }
    }
}
