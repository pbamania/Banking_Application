using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using banking_app.Business.Service;
using banking_app.DataAccess.Dtos;

namespace banking_app.UI
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        public static int USERID = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Please enter email and password to login");
                }
                else
                {
                    string email = this.txtEmail.Text;
                    string password = this.txtPassword.Text;
                    USERID = MainService.getInstance().GetUserService().getUserIdByEmail(email);
                    MainService.getInstance().GetUserService().CheckLogIn(email, password);
                }

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
