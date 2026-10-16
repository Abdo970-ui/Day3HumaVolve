
using Serilog;

namespace Day3HumaVolve
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // log
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Information()
                 .Enrich.FromLogContext()
                 .Enrich.WithProperty("Application", "EmployeeApi")
                 .WriteTo.Console()
                 .WriteTo.File(
                 "logs/log-.txt",
                 rollingInterval: RollingInterval.Day)
                 .CreateLogger();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
