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
    public partial class DepositView : Form
    {
        public DepositView()
        {
           InitializeComponent();
        }

        public void OpenModal()
        {
            this.ShowDialog();
        }

        private void btnCreateDepo_Click(object sender, EventArgs e)
        {
            try
            {
                string currency = (string)this.comboCurrencyDepo.SelectedItem;
                double amount = double.Parse(txtAmounDepo.Text);
                TransactionDTO trans = new TransactionDTO("deposit", amount, currency);
                MainService.getInstance().GetTransactionService().saveNewTransaction(trans);
                if (MainService.getInstance().GetAccountTransactionService().LinkTransactionToAccount(trans.Id, WelcomeForm.ACCOUNTNUMBER))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Transaction cannot proceed, please try again!");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
    }
}
