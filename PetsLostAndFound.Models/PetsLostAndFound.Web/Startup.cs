namespace PetsLostAndFound.Web
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Cors.Internal;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetsLostAndFound.Db;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Web.Infrastructure.Extencions;

    public class Startup
  {
    public Startup(IConfiguration configuration, IHostingEnvironment env)
    {
      Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

   
    public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PetsDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<PetsDbContext>()
                .AddDefaultTokenProviders();

            services.AddDomainServices();

            services.AddAutoMapper();

            services.AddRouting(routing => routing.LowercaseUrls = true);

            //services.AddCors();

            ////services.AddMvc();
            ////services.Configure<MvcOptions>(options =>
            ////{
            ////  options.Filters.Add(new CorsAuthorizationFilterFactory("http://localhost:4200"));
            ////});

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200"));
            });

            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling =
                                                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var corsBuilder = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            //corsBuilder.WithOrigins("http://localhost:4200"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
                });
        }
        
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseDatabaseMigration();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
        app.UseDatabaseErrorPage();
      }

            //app.UseStaticFiles();

            // app.UseAuthentication();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();

        app.UseCors("SiteCorsPolicy");
    }
  }
}
