using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;
using DentistClinic_PresentationTier.Controls.MainUIControls;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;

namespace DentistClinic_PresentationTier
{
    public partial class frmMain : Form
    {
        private IRoleService _roleService;
        private UserControl _activeControl = null;
        private ISessionContext _sessionContext;
        public frmMain(ISessionContext sessionContext,IRoleService roleService)
        {
            _roleService = roleService;
            _sessionContext = sessionContext;
            InitializeComponent();
            this.DoubleBuffered = true;
            
        }

        //Enables WS_EX_COMPOSITED so all child controls(panels, etc.) are double-buffered too
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }
        private async void frmMain_Load(object sender, EventArgs e)
        {
            await _loadRolesFromDB();
            _createButtons();
            var dashboard = Program.ServiceProvider.GetRequiredService<ctrlDashBoard>();
            CreateView(dashboard);
        }
        private void CreateView(object control)
        {
            mainLayoutPanel.SuspendLayout();
            
                var newPage = control as UserControl;

                if (_activeControl != null && newPage != null)
                {
                    this.mainLayoutPanel.Controls.Remove(_activeControl);
                    _activeControl.Dispose();
                }
                else if (newPage == null)
                {
                    return;
                }

                newPage.Dock = DockStyle.Fill;
                newPage.Margin = new Padding(0);
                this.mainLayoutPanel.Controls.Add(newPage, 0, 0);
                this.mainLayoutPanel.SetRowSpan(newPage, 2);

                _activeControl = newPage;

            mainLayoutPanel.ResumeLayout(true);
        }

        //UI events
        private async void DynamicButtons_Click(object sender , EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;

            switch (btn.Name)
            {
                case "btnDashboard":
                    if (_isOkToDo(myEnums.enPermission.Dashboard))
                    {
                        var wantedCtrl = Program.ServiceProvider.GetRequiredService<ctrlDashBoard>();
                        CreateView(wantedCtrl);
                    }
                    break;
                case "btnManagePatients":
                    if (_isOkToDo(myEnums.enPermission.ManagePatients))
                    {
                        var wantedCtrl = Program.ServiceProvider.GetRequiredService<ctrlManagePatients>();
                        CreateView(wantedCtrl);
                    }
                    break;
                case "btnManageAppointments":
                    if (_isOkToDo(myEnums.enPermission.ManageAppointments))
                    {
                        var wantedCtrl = Program.ServiceProvider.GetRequiredService<ctrlManageAppointment>();
                        CreateView(wantedCtrl);
                    }
                    break;
                case "btnManagePayments":
                    if (_isOkToDo(myEnums.enPermission.ManagePayments))
                    {
                        var wantedCtrl = Program.ServiceProvider.GetRequiredService<ctrlManagePayments>();
                        CreateView(wantedCtrl);
                    }
                    break;
                case "btnManageStaff":
                    if (_isOkToDo(myEnums.enPermission.ManageStaff))
                    {
                        var wantedCtrl = Program.ServiceProvider.GetRequiredService<ctrlManageStaff>();
                        CreateView(wantedCtrl);
                    }
                    break;
                case "btnManageRoles":
                    if (_isOkToDo(myEnums.enPermission.ManageRoles))
                    {
                        var wantedCtrl = Program.ServiceProvider.GetRequiredService<ctrlManageRoles>();
                        CreateView(wantedCtrl);
                    }
                    break;
                case "btnReports":
                    if (_isOkToDo(myEnums.enPermission.ManageReports))
                    {
                        var wantedCtrl = Program.ServiceProvider.GetRequiredService<ctrlManageReports>();
                        CreateView(wantedCtrl);
                    }
                    break;
                case "btnLogout":
                    Application.Restart();
                    break;
                default:
                    break;
            }
        }
        //buttons creation
        private void _createButtons()
        {
            List<Guna2Button> buttons = new List<Guna2Button>
            {
                new Guna2Button
                {
                        Name = "btnDashboard",
                        Text = "لوحة التـحكم",
                        Image = Properties.Resources.Dashboard
                },
                new Guna2Button
                {
                        Name = "btnManagePatients",
                        Text = "إدارة المرضى",
                        Image = Properties.Resources.ManagePatients
                },
                new Guna2Button
                {
                        Name = "btnManageAppointments",
                        Text = "إدارة المواعيد",
                        Image = Properties.Resources.ManageAppointment
                },
                new Guna2Button
                {
                        Name = "btnManagePayments",
                        Text = "إدارة المدفوعات",
                        Image = Properties.Resources.ManagePayments
                },
                new Guna2Button
                {
                        Name = "btnManageStaff",
                        Text = "إدارة الكادر",
                       Image = Properties.Resources.ManageStaff
                },
                new Guna2Button
                {
                        Name = "btnManageRoles",
                        Text = "إدارة الصلاحيات",
                        Image = Properties.Resources.ManageRoles
                },new Guna2Button
                {
                        Name = "btnReports",
                        Text = "التقارير",
                        Image = Properties.Resources.ManageReports
                },new Guna2Button
                {
                        Name = "btnLogout",
                        Text = "تسجيل خروج",
                        Image = Properties.Resources.Logout
                }
            };

            flowLayoutPanelButtons.SuspendLayout();
            foreach (Guna2Button button in buttons)
            {
                if (_isButtonVisible(button) || button.Name == "btnLogout")
                {
                    _buildButtons(button);
                }
            }
            flowLayoutPanelButtons.ResumeLayout(true);
        }      
        private void _buildButtons(Guna2Button button)
        {
            
            button.BorderColor = System.Drawing.Color.Transparent;
            button.BorderRadius = 20;
            button.BorderThickness = 2;
            button.Margin  = new Padding(10,10,10,10);
            button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            button.FillColor = System.Drawing.Color.Transparent;
            button.Font = new System.Drawing.Font("Segoe UI", 13F,FontStyle.Bold);
            button.ForeColor = System.Drawing.Color.White;
            button.HoverState.BorderColor = System.Drawing.Color.White;
            //button.HoverState.FillColor = System.Drawing.Color.Transparent;
            //button.ImageOffset = new System.Drawing.Point(27, -30);
            button.ImageSize = new System.Drawing.Size(80, 80);
            button.Size = new System.Drawing.Size(350, 100);
            //button.TextOffset = new System.Drawing.Point(-34, 70);
            button.ImageAlign = HorizontalAlignment.Right;
            button.TextAlign = HorizontalAlignment.Right;
            button.Click += DynamicButtons_Click;

            flowLayoutPanelButtons.Controls.Add(button);
        }

        //Helper methods
        private async Task _loadRolesFromDB()
        {
            try
            {
                clsAuth.DataBaseRoles = await _roleService.GetAllRolesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشكلة في الحصول على بيانات التصاريح و الرجاء الاتصال على يامن واخذ صورة للتنبيه \n " +"Error => ("+ ex.Message + ")", "Error" , MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private bool _isOkToDo(myEnums.enPermission enPermission)
        {
            if (clsAuth.IsAuth(_sessionContext.Staff.RoleInfo.RolePermissionCode, enPermission))
            {
                return true;
            }
            MessageBox.Show("ليس لديك الصلاحيات لفعل هذا الامر\nكلم الادمن اذا هناك خطا", "رفض وصول", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }
        private bool _isButtonVisible(Guna2Button btn)
        {
            switch (btn.Name)
            {
                case "btnDashboard":
                    if (!clsAuth.IsAuth(_sessionContext.Staff.RoleInfo.RolePermissionCode, myEnums.enPermission.ManagePatients))
                    {
                        return false;
                    }
                    return true;
                case "btnManagePatients":
                    if (!clsAuth.IsAuth(_sessionContext.Staff.RoleInfo.RolePermissionCode, myEnums.enPermission.ManagePatients))
                    {
                        return false;
                    }
                    return true;
                case "btnManageAppointments":
                    if (!clsAuth.IsAuth(_sessionContext.Staff.RoleInfo.RolePermissionCode, myEnums.enPermission.ManageAppointments))
                    {
                        return false;
                    }
                    return true;
                case "btnManagePayments":
                    if (!clsAuth.IsAuth(_sessionContext.Staff.RoleInfo.RolePermissionCode, myEnums.enPermission.ManagePayments))
                    {
                        return false;
                    }
                    return true;
                case "btnManageStaff":
                    if (!clsAuth.IsAuth(_sessionContext.Staff.RoleInfo.RolePermissionCode, myEnums.enPermission.ManageStaff))
                    {
                        return false;
                    }
                    return true;
                case "btnManageRoles":
                    if (!clsAuth.IsAuth(_sessionContext.Staff.RoleInfo.RolePermissionCode, myEnums.enPermission.ManageRoles))
                    {
                        return false;
                    }
                    return true;
                case "btnReports":
                    if (!clsAuth.IsAuth(_sessionContext.Staff.RoleInfo.RolePermissionCode, myEnums.enPermission.ManageReports))
                    {
                        return false;
                    }
                    return true;
                default:
                    return false;
            }
        }
    }
}
