using System.Diagnostics;
using BethanyPieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BethanyPieShop {
  public class Startup {
    public IConfiguration Configuration { get; }

    public Startup (IConfiguration configuration) {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices (IServiceCollection services) {

      services.AddScoped<IPieRepository, PieRepository> ();
      services.AddScoped<ICategoryRepository, CategoryRepository> ();

      services.AddControllersWithViews ();

      services.AddDbContext<AppDbContext> (x =>
        x.UseSqlite (Configuration.GetConnectionString ("DefaultConnection")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {

      app.Use (async (context, next) => {
        context.Items.Add ("greeting", "Hello World!");

        Debug.WriteLine ("Before");
        await next.Invoke ();
        Debug.WriteLine ("After");
      });

      /*       app.Run (async context => {
              await context.Response.WriteAsync ("Ciao: " + context.Items["greeting"]);
            }); */

      if (env.IsDevelopment ()) {
        app.UseDeveloperExceptionPage ();
      }

      app.UseHttpsRedirection ();
      app.UseStaticFiles ();

      app.UseRouting ();

      app.UseEndpoints (endpoints => {
        // endpoints.MapRazorPages ();
        endpoints.MapControllerRoute (
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
      });

    }
  }
}