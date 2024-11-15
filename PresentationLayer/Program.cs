using BusinessLogicLayer;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;  
    options.Cookie.IsEssential = true;  
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
