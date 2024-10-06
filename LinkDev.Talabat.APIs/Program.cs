
using LinkDev.Talabat.Infrastructure.Presistance;
using LinkDev.Talabat.Infrastructure.Presistance.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.APIs
{
    public class Program
    {

        //[FromServices]
        //public static StoreContext StoreContext { get; set; } = null!;

        public static async Task Main(string[] args)
        {
            var WebApplicatioBuilder = WebApplication.CreateBuilder(args);

            #region Configure Services
            // Add services to the container.

            WebApplicatioBuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            WebApplicatioBuilder.Services.AddEndpointsApiExplorer();
            WebApplicatioBuilder.Services.AddSwaggerGen();


            WebApplicatioBuilder.Services.AddPresistanceServices(WebApplicatioBuilder.Configuration);

            //DependencyInjection.AddPresistanceServices(WebApplicatioBuilder.Services, WebApplicatioBuilder.Configuration);



            #endregion

            #region Database Update and Data Seed
            var app = WebApplicatioBuilder.Build();

            using var Scope = app.Services.CreateAsyncScope();
            var Services = Scope.ServiceProvider;
            var DbContext = Services.GetRequiredService<StoreContext>();
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();

            try
            {
                var penddingMigration = DbContext.Database.GetPendingMigrations();
                if (penddingMigration.Any())
                    await DbContext.Database.MigrateAsync(); // Apply All Pendding Migrations - UpdateDatabase

                    await StoreDbContextSeed.SeedAsync(DbContext);

            }
            catch (Exception ex)
            {

                var Logger = LoggerFactory.CreateLogger<Program>();

                Logger.LogError(ex, "An Error has been occure :(");

            }

            #endregion

            #region Configure Kestrel MiddleWars
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
