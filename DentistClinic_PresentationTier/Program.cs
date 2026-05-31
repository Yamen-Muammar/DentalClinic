using System;
using System.Collections.Generic;
using System.Configuration;
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
            string connStr = ConfigurationManager.ConnectionStrings["DentalClinic"].ConnectionString;

            // Repositories — factory lambda required because ctor takes a plain string
            services.AddTransient<IStaffRepository>(p => new StaffRepository(connStr));
            services.AddTransient<IPatientRepository>(p => new PatientRepository(connStr));
            services.AddTransient<IDoctorRepository>(p => new DoctorRepository(connStr));
            services.AddTransient<IMedicalFileRepository>(p => new MedicalFileRepository(connStr));
            services.AddTransient<IProblemRepository>(p => new ProblemRepository(connStr));
            services.AddTransient<IAppointmentRepository>(p => new AppointmentRepository(connStr));
            services.AddTransient<IPaymentRepository>(p => new PaymentRepository(connStr));
            services.AddTransient<IBloodTypeRepository>(p => new BloodTypeRepository(connStr));
            services.AddTransient<IRoleRepository>(p => new RoleRepository(connStr));
            services.AddTransient<IPersonRepository>(p => new PersonRepository(connStr));

            // Services — DI resolves their repository dependency automatically
            services.AddTransient<IStaffService, StaffService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IMedicalFileService, MedicalFileService>();
            services.AddTransient<IProblemService, ProblemService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IBloodTypeService, BloodTypeService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPersonService, PersonService>();

            // Forms
            services.AddTransient<frmLogin>();
            services.AddTransient<frmMain>();
        }
    }
}
