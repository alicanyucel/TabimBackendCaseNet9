
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TabimBackendCaseNet8.Context;

namespace TabimBackendCaseNet8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
            });
            builder.Services.AddSwaggerGen();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = "api-docs"; 
                });
            }
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
