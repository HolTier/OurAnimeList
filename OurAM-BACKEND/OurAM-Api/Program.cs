using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OurAM_Api.Data;
using OurAM_Api.Models;

namespace OurAM_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.
            builder.Services.AddControllers();

            // Add iddentity services
            builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<OuramDbContext>()
                .AddDefaultTokenProviders();

            // Database connection
            builder.Services.AddDbContext<OuramDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Swagger configuration
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Use middleware for authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OurAM API V1");
            });

            app.MapControllers();

            app.Run();
        }
    }
}
