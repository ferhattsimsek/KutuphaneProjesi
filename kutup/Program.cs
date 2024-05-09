using kutup.Data;
using kutup.Tasks.Triggers;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options => {
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("database");
    options.UseSqlite(connectionString);
});
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var jobkey = new JobKey("JobName");
    q.AddJob<KalanGunAzaltmaJob>(opt=>opt.WithIdentity(jobkey));
    q.AddTrigger(opt =>
    opt.ForJob(jobkey).
    WithIdentity("jobname-trigger").
    WithCronSchedule("0 0/1 * * * ?")
    ); 
}

);
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Emanet}/{action=Index}/{id?}");
app.Run();
