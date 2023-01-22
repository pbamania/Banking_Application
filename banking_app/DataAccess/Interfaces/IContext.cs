using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_app.DataAccess.Interfaces
{
    public interface IContext<TDTO>: IDisposable where TDTO : class, IDto
    {
        public DbSet<TDTO> GetDbSet();
        public int SaveChange();
    }
}
