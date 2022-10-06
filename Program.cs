using Microsoft.EntityFrameworkCore;
using projetoIntegrador.Database;

namespace projetoIntegrador
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Db connection
            var connection = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<Context>(o => o.UseNpgsql(connection));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
            app.UseSwaggerUI();

            app.Run();
        }
    }
}