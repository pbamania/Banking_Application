using banking_app.DataAccess.Contexts;
using banking_app.DataAccess.DAOs;
using banking_app.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_app.Business.Service
{
    public class UserAccountService
    {
        private UserAccountDAO userAccountDAO;

        public UserAccountService(ProjectContext context)
        {
            this.userAccountDAO = new UserAccountDAO(context);
        }

        public List<AccountDTO> getAllAccountOfUser(int userId)
        {
            return this.userAccountDAO.GetAccountOfAnUser(userId).ToList();
        }

        public List<UserDTO> getAllUserOfAccount(int accountNumber)
        {
            return this.userAccountDAO.GetUserOfAnAccount(accountNumber).ToList();
        }

        public UserAccountDTO LinkAccountToUser( int userId, int accountNumber)
        {
            UserAccountDTO createdLink = new UserAccountDTO(userId, accountNumber);
            return this.userAccountDAO.Create(createdLink);
        }

        public UserAccountDTO UnlinkUserFromAccount(int userId, int accountNumber)
        {
            UserAccountDTO linkToRemove = this.userAccountDAO.GetByUserAndAccountNumber(userId, accountNumber);
            return this.userAccountDAO.Delete(linkToRemove);
        }

        public void UnlinkAllUsersFromAccount(int accountNumber)
        {
            List<UserDTO> usersOfAccount = this.userAccountDAO.GetUserOfAnAccount(accountNumber);
            foreach (UserDTO user in usersOfAccount)
            {
                UserAccountDTO userAccountToDelete = this.userAccountDAO.GetByUserAndAccountNumber(user.ID, accountNumber);
                this.userAccountDAO.Delete(userAccountToDelete);
            }

        }
        public void UnlinkAllAccountFromUser(int userId)
        {
            List<AccountDTO> accountOfUser = this.userAccountDAO.GetAccountOfAnUser(userId);
            foreach (AccountDTO account in accountOfUser)
            {
                UserAccountDTO userAccountToDelete = this.userAccountDAO.GetByUserAndAccountNumber(userId, account.AccountNumber);
                this.userAccountDAO.Delete(userAccountToDelete);
            }
        }

    }
}
