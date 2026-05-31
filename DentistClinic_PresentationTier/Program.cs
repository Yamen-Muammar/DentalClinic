using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_BusinessTier.Services;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_DataTier.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DentistClinic_PresentationTier
{
    internal static class Program
    {
        // This static property exposes the DI container to the rest of the application
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            // Build the brain of our DI container
            ServiceProvider = services.BuildServiceProvider();

            // RIGHT HERE: Instead of Application.Run(new LoginForm())
            // We request the form directly from our ServiceProvider container
            var loginForm = ServiceProvider.GetRequiredService<frmLogin>();

            using (loginForm = ServiceProvider.GetRequiredService<frmLogin>())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                }
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            string connectionString = "Your_Secret_Connection_String_Here";

            // Wire up your structural layers
            services.AddTransient<IStaffRepository, StaffRepository>();
            services.AddTransient<IStaffService, StaffService>();

            // CRITICAL: Register your forms so the container knows how to resolve them
            services.AddTransient<frmLogin>();
            services.AddTransient<frmMain>();
        }
    }
}
