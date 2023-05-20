using Microsoft.EntityFrameworkCore;

namespace Financial_DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder) : base(optionsBuilder)
    {
    }

    public virtual DbSet<Transaction> Transactions => Set<Transaction>();
    public virtual DbSet<Category> Categories => Set<Category>();
    public virtual DbSet<Sale> Sales => Set<Sale>();
    public virtual DbSet<Customer> Customers => Set<Customer>();
    public virtual DbSet<Statu> Status => Set<Statu>();
    public virtual DbSet<Source> Sources => Set<Source>();
    public virtual DbSet<ToDoList> ToDoLists=> Set<ToDoList>();
    public virtual DbSet<Priority> Priority => Set<Priority>();
    public virtual DbSet<Assign> Assigns => Set<Assign>();

}

