using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SomeDotes.Models.Interfaces;
using SomeDotes.Services.RealTimeService;

namespace SomeDotes
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
            services.AddMvc();

            services.AddSingleton<IRegisterCurrentGameService, RegisterCurrentGameService>();
            services.AddSingleton<IPreGameStatisticsService, PreGameStatisticsService>();
            services.AddSingleton<CurrentGameService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=CurrentGame}/{id?}");
            });

            

            Bootstrap();
        }

        public async void Bootstrap()
        {
            var options = new BrowserWindowOptions
            {
                Show = false
            };

            var mainWindow = await Electron.WindowManager.CreateWindowAsync(options);
            mainWindow.OnReadyToShow += () =>
            {
                mainWindow.Show();
            };

            var menu = new[]
            {
                new MenuItem
                {
                    Label = "File",
                    Submenu = new[]
                    {
                        new MenuItem
                        {
                            Label = "Exit",
                            Click = () => { Electron.App.Exit(); }
                        }
                    }
                },
                new MenuItem
                {
                    Label = "Info",
                    Click = () => { Electron.Dialog.ShowMessageBoxAsync("Fucking shit Electron"); }
                }
            };

            Electron.Menu.SetApplicationMenu(menu);
        }
    }
}
