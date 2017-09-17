using Microsoft.EntityFrameworkCore;
using ReimbursementApp.Model;

namespace ReimbursementApp.DbContext
{
    public class ExpenseReviewDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ExpenseReviewDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Approver> Approvers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //While deploying to azure, make sure to change the connection string based on azure settings
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ExpenseReviewSPA;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        public ExpenseReviewDbContext(DbContextOptions<ExpenseReviewDbContext> options) : base(options)
        {
            //It will look for connection string from appsettings

        }

    }
}
