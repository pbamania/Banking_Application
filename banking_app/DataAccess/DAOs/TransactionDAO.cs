using banking_app.DataAccess.Contexts;
using banking_app.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_app.DataAccess.DAOs
{
    public class TransactionDAO
    {
        private ProjectContext context;

        public TransactionDAO(ProjectContext context)
        {
            this.context = context;
        }

        public TransactionDTO GetTransactionById(int id)
        {
            return this.context.Transactions.Where(transaction => transaction.Id == id).Single();
        }

        public List<TransactionDTO> GetAll()
        {
            return this.context.Transactions.ToList();
        }

        public TransactionDTO Create(TransactionDTO newTransaction)
        {
            this.context.Transactions.Add(newTransaction);
            this.context.SaveChanges();
            return newTransaction;
        }

        public TransactionDTO Update(TransactionDTO trans)
        {
            this.context.Transactions.Update(trans);
            this.context.SaveChanges();
            return trans;
        }

        public TransactionDTO Delete(TransactionDTO trans)
        {
            this.context.Transactions.Remove(trans);
            this.context.SaveChanges();
            return trans;
        }
    }
}
