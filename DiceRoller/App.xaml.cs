using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Windows;

namespace DiceRoller
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            // set up the application host with the default values for logging
            // and configuration, specifying the services we want to load in the
            // ConfigureServices method
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .Build();
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(this.GetType());

            services.AddSingleton<MainWindow>();
            services.AddSingleton<Random>();

            services.AddMediatR(assembly);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            // start the host
            await host.StartAsync();

            // retrieve the main window from the DI container so that
            // we will have all of our depenancies injected and available
            // at runtime.
            var window = host.Services.GetRequiredService<MainWindow>();

            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                // ensure we stop the host in a way that will allow for 
                // graceful shutdown and disposing
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
