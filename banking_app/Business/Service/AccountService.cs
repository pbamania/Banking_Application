

using banking_app.DataAccess.Contexts;
using banking_app.DataAccess.DAOs;
using banking_app.DataAccess.Dtos;
using banking_app.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_app.Business.Service
{
    public class AccountService : IService
    {
        

        private AccountDAO accountDAO;
        public AccountService(ProjectContext dbContext)
        {
            this.accountDAO = new AccountDAO(dbContext);
        }

        public List<AccountDTO> GetAllAccounts()
        {
            return this.accountDAO.GetAll();
        }

        public AccountDTO getAccountByAccountNumber(int accountNumber)
        {
            return this.accountDAO.GetByAccountNumber(accountNumber);
        }

        public AccountDTO saveNewAccount(AccountDTO newAccount)
        {
            return this.accountDAO.Create(newAccount);
        }

        public void updateAccount(AccountDTO account)
        {
            this.accountDAO.SaveModification(account);
        }
     }
}
