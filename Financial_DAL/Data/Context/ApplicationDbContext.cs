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
    public virtual DbSet<MainCategory> MainCategories => Set<MainCategory>();
    public virtual DbSet<SubCategory> SubCategories => Set<SubCategory>();
    public virtual DbSet<UserDatabase> UserDatabases => Set<UserDatabase>();


    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            var entity = entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.GetType().GetProperty("IsDelete")?.SetValue(entity, false);
            }
            else if (entry.State == EntityState.Deleted) //&& entity is ISoftDelete
            {
                entry.State = EntityState.Modified;
                entity.GetType().GetProperty("IsDelete")?.SetValue(entity, true);
            }
            else
            {
                entry.State = EntityState.Modified;
                entity.GetType().GetProperty("IsDelete")?.SetValue(entity, false);
            }
        }
        return base.SaveChanges();
    }

}

