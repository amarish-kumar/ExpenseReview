using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReimbursementApp.Model;

namespace ReimbursementApp.DbContext
{
    public class ExpenseReviewDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private bool _b;
        private bool _c;

        public ExpenseReviewDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Approver> Approvers { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Bill> Bills  { get; set; }
        public DbSet<Admin> Admins { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Expense>().HasOne(e => e.Employees);
            modelBuilder.Entity<Expense>().HasOne(e => e.Approvers);
            modelBuilder.Entity<Expense>().HasOne(e => e.ExpCategory);
            modelBuilder.Entity<Expense>().HasOne(e => e.Approvers);
            modelBuilder.Entity<Expense>().HasOne(e => e.ExpCategory);*/
            //Setup The foreign Key relationship, especially for expense
            //            modelBuilder.Entity<Expense>().HasOne(e => e.Employees).WithOne(d => d.EmployeeId);
            /* modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
             modelBuilder.Entity<Approver>().HasKey(a => a.ApproverId);*/
            //TODO: Set Composite Keys here. Need to check for EF-Core.
            /* _b = ((modelBuilder.Entity<Employee>().HasKey(e => new {e.Id, e.EmployeeId}).Metadata.Properties[0]
                        .ValueGenerated & ValueGenerated.OnAdd) != 0);
 
             _c = (modelBuilder.Entity<Approver>().HasKey(e => new { e.Id, e.ApproverId }).Metadata.Properties[0]
                       .ValueGenerated & ValueGenerated.OnAdd) != 0;*/
            base.OnModelCreating(modelBuilder);
        }
    }
}
