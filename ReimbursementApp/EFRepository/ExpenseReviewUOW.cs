using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReimbursementApp.Data.Contracts;
using ReimbursementApp.DatabaseHelpers;
using ReimbursementApp.DbContext;
using ReimbursementApp.Model;

namespace ReimbursementApp.EFRepository
{
    public class ExpenseReviewUOW : IExpenseReviewUOW, IDisposable
    {
        public ExpenseReviewUOW(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Expense> Expenses { get { return GetStandardRepo<Expense>(); } }




        public void Commit()
        {
            DbContext.SaveChanges();
        }



        protected void CreateDbContext()
        {
            DbContext = new ExpenseReviewDbContext();
        }


        protected IRepositoryProvider RepositoryProvider { get; set; }


        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }
        private ExpenseReviewDbContext DbContext { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
    }
}
