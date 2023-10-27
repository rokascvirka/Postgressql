using Microsoft.EntityFrameworkCore;
using Postgressql.DbContexts;
using Postgressql.Interfaces;
using Postgressql.Models;
using Postgressql.Repositories;
using Postgressql.Services;

namespace Postgressql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<ISessionRepository, SessionRepository>();



            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            //add default session object everytime i start session
            using var scope = app.Services.CreateScope();
            var sessionservice = scope.ServiceProvider.GetRequiredService<ISessionService>();
            var newsession = new Session();
            sessionservice.AddSessionAsync(newsession).Wait(); 



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}