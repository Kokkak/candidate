
using BrandNewDaysCL1.Domain.Data;
using BrandNewDaysCL1.Services;

namespace BrandNewDayCL1
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var bankAccounts = new List<BankAccount> {
                new BankAccount{
                    FirstName = "Hirun",
                    LastName = "Jaingam",
                    Amount = 10,
                    IBAN = "GB35ISUB00235724700100"
                },
                  new BankAccount{
                    FirstName = "Loji",
                    LastName = "Hune",
                    Amount = 20,
                    IBAN = "GB71PJLO79075000350400"
                }
            };
            services.AddTransient<IAccountService, AccountService>();
            services.AddSingleton((IServiceProvider arg) => bankAccounts);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
        }
    }
}
