using banking_app.Business.Service;
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
    public partial class AccountCreation : Form
    {
        private userSelectorView userSelectorView;
        private UserDTO selectedUser;
        public AccountCreation()
        {
            InitializeComponent();
            this.userSelectorView = new userSelectorView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string accountType = (string)comboBoxAccType.Text;
                AccountDTO newAccount = new AccountDTO(accountType);
                MainService.getInstance().GetAccountService().saveNewAccount(newAccount);
                MainService.getInstance().GetUserAccountService().LinkAccountToUser(SignInForm.USERID, newAccount.AccountNumber);
                foreach (ListViewItem item in this.listOfUsers.Items)
                {
                    if ((int)item.Tag != SignInForm.USERID)
                    {
                        MainService.getInstance().GetUserAccountService().LinkAccountToUser((int)item.Tag, newAccount.AccountNumber);
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try { 
                this.userSelectorView.OpenModal(MainService.getInstance().GetUserService().GetAllUsers());
                if(this.userSelectorView.DialogResult == DialogResult.OK)
                {
                    this.selectedUser = this.userSelectorView.GetSelectedUser();
                    ListViewItem item = new ListViewItem(selectedUser.FullName);
                    item.Tag = selectedUser.ID;
                    this.listOfUsers.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listOfUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            try { 
                this.userSelectorView.OpenModal(MainService.getInstance().GetUserService().GetAllUsers());
                if (this.userSelectorView.DialogResult == DialogResult.OK)
                {
                    this.selectedUser = this.userSelectorView.GetSelectedUser();
               
                    foreach(ListViewItem item in this.listOfUsers.Items)
                    {
                        if(selectedUser.ID == (int)item.Tag)
                        {
                            this.listOfUsers.Items.Remove(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxAccType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
