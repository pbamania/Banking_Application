using banking_app.DataAccess.Contexts;
using banking_app.DataAccess.Dtos;
using banking_app.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_app.DataAccess.DAOs
{
    public class UserAccountDAO
    {
        private ProjectContext context;

        public UserAccountDAO(ProjectContext context)
        {
            this.context = context;
        }

        public List<UserAccountDTO> GetAll()
        {
            return this.context.UserAccounts.ToList();
        }

        public UserAccountDTO GetById(int id)
        {
            return this.context.UserAccounts.Where(userAccount => userAccount.Id == id).Single();
        }

        public List<AccountDTO> GetAccountOfAnUser(int userId)
        {
            List<UserAccountDTO> userAccounts = this.context.UserAccounts
                .Where(userAccount => userAccount.UserId == userId)
                .Include(userAccount => userAccount.Account)
                .ToList();

            List<AccountDTO> accounts = new List<AccountDTO>();
            foreach (UserAccountDTO userAccount in userAccounts)
            {
                accounts.Add(userAccount.Account);
            }
            return accounts; 
        }

        public List<UserDTO> GetUserOfAnAccount(int accountNumber)
        {
            List<UserAccountDTO> userAccounts = this.context.UserAccounts
                .Where(userAccount => userAccount.AccountNumber == accountNumber)
                .Include(userAccount => userAccount.User)
                .ToList();

            List<UserDTO> users = new List<UserDTO>();
            foreach (UserAccountDTO userAccount in userAccounts)
            {
                users.Add(userAccount.User);
            }
            return users;
        }

        public UserAccountDTO Create(UserAccountDTO newUserAccount)
        {
            this.context.UserAccounts.Add(newUserAccount);
            this.context.SaveChanges();
            return newUserAccount;
        }

        public UserAccountDTO GetByUserAndAccountNumber(int userId, int accountNumber)
        {
            return this.context.UserAccounts
                .Where(userAccount => userAccount.AccountNumber == accountNumber && userAccount.UserId == userId)
                .Single();
        }

        public UserAccountDTO Update(UserAccountDTO userAccount)
        {
            this.context.UserAccounts.Update(userAccount);
            this.context.SaveChanges();
            return userAccount;
        }

        public UserAccountDTO Delete(UserAccountDTO userAccount)
        {
            this.context.UserAccounts.Remove(userAccount);
            this.context.SaveChanges();
            return userAccount;
        }

       
        
    }
}
