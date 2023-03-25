using Microsoft.EntityFrameworkCore;
using TalabaMVC.DBContext;
using TalabaMVC.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(p =>
            p.UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnectionString")));

        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddServices();
        builder.Services.AddConfigurationIdentity();
        builder.Services.AddConfigurationJwt(builder.Configuration);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("./Home/Index");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCors("AllowAll");
        app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}