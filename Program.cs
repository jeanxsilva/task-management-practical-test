using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Services;

namespace TaskManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceCollection services = new ServiceCollection();
            configureServices(services);

            Database.Configure();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                ApplicationConfiguration.Initialize();
                MainForm mainForm = serviceProvider.GetRequiredService<MainForm>();

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                Application.Run(mainForm);
            }
        }

        private static void configureServices(ServiceCollection services)
        {
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<MainForm>();
        }
    }
}