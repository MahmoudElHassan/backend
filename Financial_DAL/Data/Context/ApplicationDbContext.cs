using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Financial_DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder) : base(optionsBuilder)
    {
    }

    public virtual DbSet<Transaction> Transactions => Set<Transaction>();
    public virtual DbSet<Category> Categories => Set<Category>();
    public virtual DbSet<Sale> Sales => Set<Sale>();
    public virtual DbSet<Payment> Payments => Set<Payment>();
    public virtual DbSet<Customer> Customers => Set<Customer>();
    public virtual DbSet<Statu> Status => Set<Statu>();
    public virtual DbSet<Source> Sources => Set<Source>();
    public virtual DbSet<ToDoList> ToDoLists => Set<ToDoList>();
    public virtual DbSet<Priority> Priority => Set<Priority>();
    public virtual DbSet<Assign> Assigns => Set<Assign>();
    public virtual DbSet<Project> Projects => Set<Project>();
    public virtual DbSet<MainCategory> MainCategories => Set<MainCategory>();
    public virtual DbSet<SubCategory> SubCategories => Set<SubCategory>();
    public virtual DbSet<UserDatabase> UserDatabases => Set<UserDatabase>();
    public virtual DbSet<Goal> Goals => Set<Goal>();
    public virtual DbSet<Area> Areas => Set<Area>();
    public virtual DbSet<Calender> Calenders => Set<Calender>();
    public virtual DbSet<Habit> Habits => Set<Habit>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calender>().Property(d => d.Days)
                   .HasConversion(z => JsonConvert.SerializeObject(z),
                   z => JsonConvert.DeserializeObject<List<int>>(z));

        modelBuilder.Entity<Habit>().Property(s => s.Status)
                   .HasConversion(z => JsonConvert.SerializeObject(z),
                   z => JsonConvert.DeserializeObject<List<bool>>(z));

        //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        //{
        //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
        //}
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            var entity = entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.GetType().GetProperty("IsDelete").SetValue(entity, false);
            }
            else if (entry.State == EntityState.Deleted) //&& entity is ISoftDelete
            {
                entry.State = EntityState.Modified;
                entity.GetType().GetProperty("IsDelete").SetValue(entity, true);
            }
            else
            {
                entry.State = EntityState.Modified;
                entity.GetType().GetProperty("IsDelete").SetValue(entity, false);
            }
        }
        return base.SaveChanges();
    }

}

