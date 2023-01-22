using banking_app.Business.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banking_app.UI
{
    public partial class UserRegisterForm : Form
    {
        public UserRegisterForm()
        {
            InitializeComponent();
        }

        public Boolean checkInvalidChar(TextBox aInput)
        {
            char[] invalidChars = new char[] { ';', '?', '`' };
            if(aInput.Text.IndexOfAny(invalidChars) != -1)
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is TextBox)
                    {
                        ((TextBox)txt).ForeColor = DefaultForeColor;
                    }
                }
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSIN.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtPass.Text))
                {
                    MessageBox.Show("Please fill out all the information!");
                }
                else if (!Regex.IsMatch(this.txtSIN.Text, @"^[\d]{9}$"))
                {
                    MessageBox.Show("Please check your SIN number, need to be 9 digits");
                    this.txtSIN.ForeColor = Color.Red;
                }
                else if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Please enter the valid email");
                    this.txtEmail.ForeColor = Color.Red;
                }
                else if(!Regex.IsMatch(this.txtPhone.Text, @"^[\d]{3}-[\d]{3}-[\d]{4}$"))
                {
                    MessageBox.Show("Please check your phone number, need to be in the format 111-111-1111");
                    this.txtPhone.ForeColor = Color.Red;
                }
                else if (!Regex.IsMatch(this.txtPass.Text, @"^[\w]{6,}$"))
                {
                    MessageBox.Show("Your password needs contains at least 6 characters");
                    this.txtPass.ForeColor = Color.Red;
                }
                else if (checkInvalidChar(txtEmail) || checkInvalidChar(txtName) || checkInvalidChar(txtPass))
                {
                    MessageBox.Show("Please check your input, no special character ; , ? ` allowed");

                }
                else if (!MainService.getInstance().GetUserService().CheckEmailExist(this.txtEmail.Text))
                {
                    MessageBox.Show("This email already exist!");
                }
                else
                {
                    string fullName = this.txtName.Text;
                    string email = this.txtEmail.Text;
                    int sin = int.Parse(txtSIN.Text);
                    this.txtSIN.ForeColor = SystemColors.WindowText;
                    string phone = this.txtPhone.Text;
                    string password = this.txtPass.Text;
                    MainService.getInstance().GetUserService().CreateNewUser(fullName, sin, password, email, phone);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainService.getInstance().GetUserService().CloseUserCreationForm();
            MainService.getInstance().GetUserService().OpenSignInForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSIN_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }


    }
}

