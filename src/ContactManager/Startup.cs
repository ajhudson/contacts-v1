using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using ContactManager.Config;
using ContactManager.Entities;
using ContactManager.DataModels;
using Microsoft.EntityFrameworkCore;
using ContactManager.Services;

namespace ContactManager
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();

            string appPath = env.ContentRootPath;
            string wwwRootPath = env.WebRootPath;

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IAppSettings, AppSettings>();
            services.AddSingleton<IRepository<Contact>, ContactsInMemoryRepository>();
            //services.AddSingleton<IRepository<Contact>, ContactsDbRepository>();

            string connString = Configuration.GetValue<string>("AppSettings:ConnectionString");
            services.AddDbContext<ContactContext>(options => options.UseSqlServer(connString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IAppSettings appSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(string.Format("Application Name: {0}", appSettings.Title));
            });
        }
    }
}
