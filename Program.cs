using Microsoft.EntityFrameworkCore;
using projetoIntegrador.Database;
using projetoIntegrador.Interfaces.Repositories;
using projetoIntegrador.Interfaces.Services;
using projetoIntegrador.Repositories;
using projetoIntegrador.Services;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;

namespace projetoIntegrador
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Add services to the container.
            //Db connection
            var connection = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<Context>(option => option.UseNpgsql(connection));

            //INTERFACE e REPOSITORY
            builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
            builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
            builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
            builder.Services.AddScoped<ISalaRepository, SalaRepository>();

            //INTERFACE e SERVICE
            builder.Services.AddScoped<IAlunoService, AlunoService>();
            builder.Services.AddScoped<IProfessorService, ProfessorService>();
            builder.Services.AddScoped<IMateriaService, MateriaService>();
            builder.Services.AddScoped<ISalaService, SalaService>();


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

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            );

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}