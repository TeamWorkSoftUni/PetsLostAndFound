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
<<<<<<< HEAD
  using PetsLostAndFound.Db;
  using PetsLostAndFound.Db.Models;
  using PetsLostAndFound.Web.Infrastructure.Extencions;
=======
  using PetsLostAndFound.Data;
  using PetsLostAndFound.Data.Models;
>>>>>>> e56d7b23ebf54997a9494fc880acbacc9cd5faff
  using Services;

  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
<<<<<<< HEAD

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
=======

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<PetsDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddIdentity<User, IdentityRole>(options =>
        {
          options.Password.RequireDigit = false;
          options.Password.RequireNonAlphanumeric = false;
          options.Password.RequireLowercase = false;
          options.Password.RequireUppercase = false;
        })
          .AddEntityFrameworkStores<PetsDbContext>()
          .AddDefaultTokenProviders();

      // Add application services.
      services.AddTransient<IEmailSender, EmailSender>();

      //services.AddCors();

      //services.AddMvc();
      //services.Configure<MvcOptions>(options =>
      //{
      //  options.Filters.Add(new CorsAuthorizationFilterFactory("http://localhost:4200"));
      //});

      //services.AddMvc(options =>
      //{
      //  options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
      //});

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

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      //app.Use(async (context, next) =>
      //{
      //  await next();
      //  if (context.Response.StatusCode == 404 &&
      //      !Path.HasExtension(context.Request.Path.Value) &&
      //      !context.Request.Path.Value.StartsWith("/api/"))
      //  {
      //    context.Request.Path = "/index.html";
      //    await next();
      //  }
      //});

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
      });
>>>>>>> e56d7b23ebf54997a9494fc880acbacc9cd5faff
    }
  }
}