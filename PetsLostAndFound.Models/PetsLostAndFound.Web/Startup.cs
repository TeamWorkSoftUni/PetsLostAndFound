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

  using Services;

  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
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

            services.AddCors();

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

            services.AddMvc();

            services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
                });
        }

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

      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvc();
    }
  }
}
