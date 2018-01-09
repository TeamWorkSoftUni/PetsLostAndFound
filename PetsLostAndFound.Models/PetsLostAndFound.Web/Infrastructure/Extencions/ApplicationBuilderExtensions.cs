namespace PetsLostAndFound.Web.Infrastructure.Extencions
{
  using Microsoft.AspNetCore.Builder;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.DependencyInjection;
  using PetsLostAndFound.Db;

  public static class ApplicationBuilderExtensions
  {
    public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
      {
        serviceScope.ServiceProvider.GetRequiredService<PetsDbContext>().Database.Migrate();
      }

      return app;
    }
  }
}
