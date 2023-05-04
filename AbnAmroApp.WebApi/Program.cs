using AbnAmroApp.BusinessLogic.Services;

namespace AbnAmroApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // TODO: make the selection configurable
            //builder.Services.AddTransient<ICalculator, InMemoryCalculator>();
            builder.Services.AddTransient<ICalculator, InDatabaseCalculator>();

            builder.Services.AddSingleton<ICalculationService, CalculationService>();
            builder.Services.AddSingleton<ICalculationManager, CalculationManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}