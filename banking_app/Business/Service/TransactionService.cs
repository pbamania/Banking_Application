﻿using banking_app.DataAccess.Contexts;
using banking_app.DataAccess.DAOs;
using banking_app.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_app.Business.Service
{
    public class TransactionService
    {
        private TransactionDAO transactionDAO;

        public TransactionService(ProjectContext context)
        {
            this.transactionDAO = new TransactionDAO(context);
        }

        public TransactionDTO getTransactionById(int id)
        {
            return this.transactionDAO.GetTransactionById(id);
        }

        public TransactionDTO saveNewTransaction(TransactionDTO newTransaction)
        {
            return this.transactionDAO.Create(newTransaction);
        }

    }
}
