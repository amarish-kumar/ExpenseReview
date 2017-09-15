using System;
using ReimbursementApp.Data.Contracts;
using ReimbursementApp.Data.Helpers;
using ReimbursementApp.Model;

namespace ReimbursementApp.Data
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

  