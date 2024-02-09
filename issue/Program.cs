//using System;

namespace eqmp2
{
    static class Globals
    {
        // global var mydns
        public static string? mydns;
    }
    public class Startup
    {
        public Startup()
        {
            
        }


        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);


            //builder.ServicesAddCors(x => x.AddPolicy("CorsPolicy", y => y.AllowCredentials().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
            builder.Services.AddCors(x => x.AddPolicy("AllowAll", y => y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


            // Add services to the container.
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("AllowAll");

            app.Run();


        }

    }

}