
using BrandNewDayCL1;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Logging;
using System.Text;

namespace BrandNewDaysCL1
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var startup = new Startup(builder.Configuration);

            startup.ConfigureServices(builder.Services);

            var app = builder.Build();
            startup.Configure(app, app.Environment);
            app.MapControllers();
            RevertString("1234");
            RevertStringlastHalf("""1321111""");
            app.Run();

            123 456
            123654
            12345
            12354
        }
        public static string RevertString(string value)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = value.Length - 1; i >= 0; i--)
            {
                //reverted += value[i];
                sb.Append(value[i]);
            }
            return sb.ToString();
        }

        public static string RevertStringlastHalf(string value)
        {
            //    StringBuilder sb = new StringBuilder();
            var lenth = value.Length;
            if (lenth % 2 == 0)
            {
                var firsthalf = value.Take(lenth / 2);
                var lasthalf = RevertString(value);
                return firsthalf + lasthalf;
            }
            return "1";
        }
        /*
      
          public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
      */
        /*  public static void Main(string[] args)
          {
              var builder = WebApplication.CreateBuilder(args);

              // Add services to the container.

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

             // app.Run();
              BuildWebHost(args).Run();
          }

          public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
               .Build();

      }*/
    }
}
