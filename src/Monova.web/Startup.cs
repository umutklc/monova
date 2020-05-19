using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using monova.entity;
using VueCliMiddleware;
using Microsoft.AspNetCore.Identity;
using System;

namespace monova.web
{
  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;

    }
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<MVDContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=monova;Username=postgres;Password=000000"));

      services.AddIdentity<MVDUser, IdentityRole<Guid>>()
              .AddEntityFrameworkStores<MVDContext>()
              .AddDefaultTokenProviders()
              .AddDefaultUI();



      // Add AddRazorPages if the app uses Razor Pages.
      services.AddRazorPages();

      services.Configure<IdentityOptions>(options =>
    {
      // Password settings.
      options.Password.RequireDigit = true;
      options.Password.RequireLowercase = true;
      options.Password.RequireNonAlphanumeric = true;
      options.Password.RequireUppercase = true;
      options.Password.RequiredLength = 6;
      options.Password.RequiredUniqueChars = 1;

      // Lockout settings.
      options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
      options.Lockout.MaxFailedAccessAttempts = 5;
      options.Lockout.AllowedForNewUsers = true;

      // User settings.
      options.User.AllowedUserNameCharacters =
      "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
      options.User.RequireUniqueEmail = false;
    });

      services.ConfigureApplicationCookie(options =>
      {
        // Cookie settings
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

        options.LoginPath = "/Identity/Account/Login";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        options.SlidingExpiration = true;
      });

      services.AddControllersWithViews();



      // In production, the Vue files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/dist";
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
        app.UseHttpsRedirection();
      }

      app.UseStaticFiles();
      app.UseSpaStaticFiles();

      app.UseRouting();
      app.UseAuthorization();
      app.UseAuthentication();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action=Index}/{id?}");

        if (env.IsDevelopment())
        {
          endpoints.MapToVueCliProxy(
                    "{*path}",
                    new SpaOptions { SourcePath = "ClientApp" },
                    npmScript: "serve",
                    regex: "Compiled successfully");
        }

        // Add MapRazorPages if the app uses Razor Pages. Since Endpoint Routing includes support for many frameworks, adding Razor Pages is now opt -in.
        endpoints.MapRazorPages();
      });

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "ClientApp";
      });
    }
  }
}
