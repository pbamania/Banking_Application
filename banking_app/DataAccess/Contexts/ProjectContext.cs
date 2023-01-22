using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using banking_app.DataAccess.Dtos;
using Microsoft.EntityFrameworkCore;

namespace banking_app.DataAccess.Contexts
{
    public class ProjectContext: DbContext
    {
        public DbSet<AccountDTO> Accounts { get; set; }
        public DbSet<UserDTO> Users { get; set; }

        public DbSet<UserAccountDTO> UserAccounts { get; set; }

        public DbSet<TransactionDTO> Transactions { get; set; }
        public DbSet<AccountTransactionDTO> AccountTransactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQL2019EXPRESS;Database=banking_db;Integrated security=true;TrustServerCertificate=true;");
   
        }
    }
}
