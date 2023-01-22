using banking_app.Business.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banking_app.UI
{
    public partial class homeForm : Form
    {
        public homeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainService.getInstance().GetUserService().OpenUserCreationForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainService.getInstance().GetUserService().OpenSignInForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
