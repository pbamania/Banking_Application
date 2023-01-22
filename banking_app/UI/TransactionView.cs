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
    public partial class TransactionView : Form
    {
        private DepositView transDepositView;
        private TransferView transTransferView;
        private WithdrawView transWithdrawView;
        public TransactionView()
        {
            InitializeComponent();
            this.transDepositView = new DepositView();
            this.transTransferView = new TransferView();
            this.transWithdrawView = new WithdrawView();
        }

     

        private void btnCreateTrans_Click(object sender, EventArgs e)
        {
            try {
                this.transDepositView.OpenModal();
                if(this.transDepositView.DialogResult == DialogResult.OK)
                {
                    List<TransactionDTO> transactionList = MainService.getInstance().GetAccountTransactionService().getAllTransactionOfAccount(WelcomeForm.ACCOUNTNUMBER);
                    loadGridView(transactionList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<TransactionDTO> transactionList = MainService.getInstance().GetAccountTransactionService().getAllTransactionOfAccount(WelcomeForm.ACCOUNTNUMBER);
            gridViewTransactions.DataSource = transactionList;
        }

        public void loadGridView(List<TransactionDTO> transactionList)
        {
            gridViewTransactions.DataSource = transactionList;
        }

        public void OpenModal(List<TransactionDTO> transactionList)
        {
            this.loadGridView(transactionList);
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            try { 
                this.transWithdrawView.OpenModal();
                if (this.transWithdrawView.DialogResult == DialogResult.OK)
                {
                    List<TransactionDTO> transactionList = MainService.getInstance().GetAccountTransactionService().getAllTransactionOfAccount(WelcomeForm.ACCOUNTNUMBER);
                    loadGridView(transactionList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try { 
                this.transTransferView.OpenModal(MainService.getInstance().GetAccountService().GetAllAccounts());
                if (this.transTransferView.DialogResult == DialogResult.OK)
                {
                    List<TransactionDTO> transactionList = MainService.getInstance().GetAccountTransactionService().getAllTransactionOfAccount(WelcomeForm.ACCOUNTNUMBER);
                    loadGridView(transactionList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TransactionView_Load(object sender, EventArgs e)
        {

        }
    }
}
