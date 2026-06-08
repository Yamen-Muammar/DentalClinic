using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_BusinessTier.Services;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentistClinic_PresentationTier
{
    public partial class frmLogin : Form
    {
        private IStaffService _staffService;
        private ISessionContext _sessionContext;
        public frmLogin(ISessionContext sessionContext,IStaffService staffService)
        {
            InitializeComponent();
            _staffService = staffService;
            _sessionContext = sessionContext;
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                this.Invoke((Action) (() =>
                {
                    _startLoading(true);
                }));        
            });
          
           
            try
            {
                if (string.IsNullOrEmpty(tbUsername.Text))
                {
                    MessageBox.Show("يرجـئ إدخال اسم المستخدم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbUsername.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(tbPassword.Text))
                {
                    MessageBox.Show("يرجـئ إدخال كلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPassword.Focus();
                    return;
                }

                string username = tbUsername.Text;
                string password = tbPassword.Text;

                clsStaff loggedinStaff = await _staffService.LoginAsync(username, password);

                if (loggedinStaff != null)
                {
                    _sessionContext.Set(loggedinStaff);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (InvalidCredentialException)
            {
                MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("الرجاء الاتصال في آدمن\n->>Error"+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                _startLoading(false);
            }
        }
        private void _startLoading(bool enable)
        {
            btnLogin.Enabled = !enable;
            if (!enable)
            {
                guna2WinProgressIndicator1.Stop();
                guna2WinProgressIndicator1.Visible = false;
                btnLogin.Text = "دخول";
            }
            else
            {
                guna2WinProgressIndicator1.Start();
                btnLogin.Enabled = false;
                btnLogin.Text = "";
                guna2WinProgressIndicator1.Visible = true;
            }
            
        }
        private void btnVisionChar_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;

            if (!tbPassword.UseSystemPasswordChar)
            {
                btnVisionChar.FillColor = Color.White;
            }
            else
            {
                btnVisionChar.FillColor = Color.Transparent;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
