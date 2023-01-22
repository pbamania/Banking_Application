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
    public partial class TransferView : Form
    {
        private AccountDTO selectedAccount;
        public TransferView()
        {
            InitializeComponent();
            this.comboAccount.DisplayMember = "AccountNumber";
            this.comboAccount.ValueMember = "AccountNumber";

        }
        public void OpenModal(List<AccountDTO> selectableAccounts)
        {
            this.LoadAccountListInCombobox(selectableAccounts);
            this.ShowDialog();
        }


        private void comboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedAccount = (AccountDTO)this.comboAccount.Items[this.comboAccount.SelectedIndex];
        }

        private void LoadAccountListInCombobox(List<AccountDTO> selectableAccounts)
        {
            try { 
                this.comboAccount.Items.Clear();
                foreach (AccountDTO account in selectableAccounts)
                {
                    this.comboAccount.Items.Add(account);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try {
                string currency = (string)this.comboBoCurrency.SelectedItem;
                double amount = double.Parse(txtAmount.Text);
                int accountContraNum = this.selectedAccount.AccountNumber;
                TransactionDTO transCredit = new TransactionDTO("transfer", amount, currency);
                MainService.getInstance().GetTransactionService().saveNewTransaction(transCredit);
                TransactionDTO transDebit = new TransactionDTO("debit", amount, currency);
                MainService.getInstance().GetTransactionService().saveNewTransaction(transDebit);
            
                if (MainService.getInstance().GetAccountTransactionService().LinkTransactionToAccount(transCredit.Id, WelcomeForm.ACCOUNTNUMBER) && MainService.getInstance().GetAccountTransactionService().LinkTransactionToAccount(transDebit.Id, accountContraNum))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Transaction cannot proceed, please try again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
