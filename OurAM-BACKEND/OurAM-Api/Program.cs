using Microsoft.EntityFrameworkCore;
using OurAM_Api.Data;
using OurAM_Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;

namespace OurAM_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Database connection
            builder.Services.AddDbContext<OuramDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services
            builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<OuramDbContext>()
                .AddDefaultTokenProviders();

            // Swagger
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
