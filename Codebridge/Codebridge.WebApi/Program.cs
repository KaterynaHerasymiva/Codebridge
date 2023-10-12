
using Codebridge.BLL.Repositories;
using Codebridge.BLL.Services;
using Codebridge.DAL.Repositories;
using Codebridge.WebApi.Mapper;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using System.Reflection;

namespace Codebridge.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRateLimiter(configureOptions =>
            {
                configureOptions.RejectionStatusCode = 429;

                configureOptions.AddFixedWindowLimiter("fixed", options =>
                {
                    options.PermitLimit = builder.Configuration.GetValue<int>("RateLimiter:PermitLimit");
                    options.Window = TimeSpan.FromSeconds(builder.Configuration.GetValue<int>("RateLimiter:IntervalInSeconds"));
                });
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(DogsProfile)));

            builder.Services.AddDbContext<DogsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CodebridgeDBConnection")));

            builder.Services.AddTransient<IPingService, PingService>();
            builder.Services.AddTransient<IDogsService, DogsService>();
            builder.Services.AddTransient<IDogRepository, DogRepository>();

            builder.Services.AddScoped<ISieveProcessor, CustomSieveProcessor>();


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

            app.UseRateLimiter();

            app.Run();
        }
    }
}