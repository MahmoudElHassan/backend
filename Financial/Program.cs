﻿using Financial_BL;
using Financial_DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Defaul Services
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var connectinString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectinString));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

#region Reposatories
builder.Services.AddScoped<ITransactionsRepo, TransactionsRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddScoped<ISalesRepo, SalesRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IStatusRepo, StatusRepo>();
builder.Services.AddScoped<ISourcesRepo, SourcesRepo>();
builder.Services.AddScoped<IToDoListRepo, ToDoListRepo>();
builder.Services.AddScoped<IPriorityrepo, PriorityRepo>();
builder.Services.AddScoped<IAssignRepo, AssignRepo>();
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IMainCatregoryRepo, MainCategoryRepo>();
builder.Services.AddScoped<ISubCategoryRepo, SubCategoryRepo>();
builder.Services.AddScoped<IUserDatabaseRepo, UserDatabaseRepo>();
builder.Services.AddScoped<IGoalRepo, GoalRepo>();
builder.Services.AddScoped<IAreaRepo, AreatRepo>();
builder.Services.AddScoped<ICalenderRepo, CalenderRepo>();
builder.Services.AddScoped<IHabitRepo, HabitRepo>();
#endregion

#region Managers
builder.Services.AddScoped<ITransactionsManager, TransactionsManager>();
builder.Services.AddScoped<ICategoriesManager, CategoriesManager>();
builder.Services.AddScoped<IPaymentManager, PaymentManager>();
builder.Services.AddScoped<ICustomersManager, CustomersManager>();
builder.Services.AddScoped<ISalesManager, SalesManager>();
builder.Services.AddScoped<ISourcesManager, SourcesManager>();
builder.Services.AddScoped<IStatusManager, StatusManager>();
builder.Services.AddScoped<IToDoListManager, ToDoListManager>();
builder.Services.AddScoped<IPriorityManager, PriorityManager>();
builder.Services.AddScoped<IAssignManager, AssignManager>();
builder.Services.AddScoped<IProjectManager, ProjectManager>();
builder.Services.AddScoped<IMainCategoryManager, MainCategoryManager>();
builder.Services.AddScoped<ISubCategoryManager, SubCategoryManager>();
builder.Services.AddScoped<IUserDatabaseManager, UserDatabaseManager>();
builder.Services.AddScoped<IGoalManager, GoalManager>();
builder.Services.AddScoped<IAreaManager, AreaManager>();
builder.Services.AddScoped<ICalenderManager, CalenderManager>();
builder.Services.AddScoped<IHabitManager, HabitManager>();
#endregion

#region Allow Cors

string allowPolicy = "AllowPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowPolicy, policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
    });
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
