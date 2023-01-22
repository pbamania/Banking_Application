using banking_app.DataAccess.Dtos;
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
    public partial class userSelectorView : Form
    {
        private UserDTO selectedUser;
        public userSelectorView()
        {
            InitializeComponent();
            this.userSelectorCombo.DisplayMember = "FullName";
            this.userSelectorCombo.ValueMember = "ID";
        }

        public void OpenModal(List<UserDTO> selectableUsers)
        {
            this.LoadUserListInCombobox(selectableUsers);
            this.ShowDialog();
        }

        public UserDTO GetSelectedUser()
        {
            return this.selectedUser;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedUser = (UserDTO)this.userSelectorCombo.Items[this.userSelectorCombo.SelectedIndex];

        }

        private void LoadUserListInCombobox(List<UserDTO> selectableUsers)
        {
            this.userSelectorCombo.Items.Clear();
            foreach(UserDTO user in selectableUsers)
            {
                this.userSelectorCombo.Items.Add(user);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
