using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GameUI.Models;
using GameEngine;
using GameEngine.Services.Interfaces;
using GameEngine.Services;
using GameEngine.Services.ComputerMove;
using GameEngine.Services.ComputerMove.MoveRules;

namespace GameUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<DummyContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DummyContext")));

            // State to remain
            services.AddSingleton<IGame>(new Game());
            services.AddSingleton<IGameLogService>(new GameLogService());

            // No state held so new instance if fine
            services.AddTransient<IWinnerService, WinnerService>();
            services.AddTransient<IComputerMove, ComputerMoveEasy>();
            services.AddTransient<IComputerMove, ComputerMoveMedium>();
            services.AddTransient<IComputerMove, ComputerMoveHard>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Game}/{action=Index}/{id?}");
            });
        }
    }
}
