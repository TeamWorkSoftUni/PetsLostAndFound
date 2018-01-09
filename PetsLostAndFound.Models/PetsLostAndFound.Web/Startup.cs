namespace PetsLostAndFound.Web
{
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
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddIdentity<User, IdentityRole>()
          .AddEntityFrameworkStores<PetsDbContext>()
          .AddDefaultTokenProviders();
      
      services.AddTransient<IEmailSender, EmailSender>();

      services.AddCors();

      services.AddMvc();
      services.Configure<MvcOptions>(options =>
      {
        options.Filters.Add(new CorsAuthorizationFilterFactory("http://localhost:4200"));
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

      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvc();
    }
  }
}
