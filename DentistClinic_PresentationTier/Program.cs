using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_BusinessTier.Services;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_DataTier;
using DentalClinic_DataTier.Repositories;
using DentistClinic_PresentationTier.Controls.MainUIControls;
using DentistClinic_PresentationTier.Controls.ModelsControls.PatientControls;
using DentistClinic_PresentationTier.Controls.ModelsControls.PersonControls;
using DentistClinic_PresentationTier.Forms.PatientsForms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            using (var loginForm = ServiceProvider.GetRequiredService<frmLogin>())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    var mainForm = ServiceProvider.GetRequiredService<frmMain>();
                    Application.Run(mainForm);
                }
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DentalClinic"].ConnectionString;

            services.AddTransient<IDbConnectionFactory>(p => new SqlConnectionFactory(connStr));

            // Repositories — DI injects IDbConnectionFactory automatically
            services.AddTransient<IStaffRepository, StaffRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IMedicalFileRepository, MedicalFileRepository>();
            services.AddTransient<IProblemRepository, ProblemRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentTypeRepository, PaymentRepository>();
            services.AddTransient<IPaymentDestinationRepository, PaymentRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IBloodTypeRepository, BloodTypeRepository>();
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
            services.AddTransient<IPaymentService, PaymentService>();
            // Forms
            services.AddTransient<frmLogin>();
            services.AddTransient<frmMain>();
            services.AddTransient<ctrlDashBoard>();
            services.AddTransient<ctrlManagePatients>();
            services.AddTransient<ctrlManageAppointment>();
            services.AddTransient<ctrlManagePayments>();
            services.AddTransient<ctrlManageReports>();
            services.AddTransient<ctrlManageStaff>();
            services.AddTransient<ctrlManageRoles>();
            services.AddTransient<ctrlPersonInformation>();
            services.AddTransient<ctrlAddOrEditePatientInformation>();
            services.AddTransient<frmAddOrEditePatientInformation>();
            // Session 
            services.AddSingleton<ISessionContext, WinFormsSessionContext>();
        }
    }
}
