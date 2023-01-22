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
    public partial class WithdrawView : Form
    {
        public WithdrawView()
        {
            InitializeComponent();
        }
        public void OpenModal()
        {
            this.ShowDialog();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try { 
                string currency = (string)this.comboCurrency.SelectedItem;
                double amount = double.Parse(txtAmount.Text);
                TransactionDTO trans = new TransactionDTO("withdraw", amount, currency);
                MainService.getInstance().GetTransactionService().saveNewTransaction(trans);
                if (MainService.getInstance().GetAccountTransactionService().LinkTransactionToAccount(trans.Id, WelcomeForm.ACCOUNTNUMBER))
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
