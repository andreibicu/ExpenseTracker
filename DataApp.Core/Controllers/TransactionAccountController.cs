using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApp.Core.Abstracts;
using DataApp.Core.Models;
namespace DataApp.Core.Controllers
{
    public class TransactionAccountController : Controller<TransactionAccount>, IAddData<TransactionAccount>, IReadData<TransactionAccount>, IModifyData<TransactionAccount>
    {
        public bool Add(TransactionAccount entity)
        {
            return this.repo.Add(entity);
        }

        public bool Update(TransactionAccount entity)
        {
            return this.repo.Update(entity);
        }

        public TransactionAccount Get(Func<TransactionAccount, bool> filter)
        {
            return this.repo.Get(filter);
        }

        public List<TransactionAccount> GetAll(Func<TransactionAccount, bool> filter = null)
        {
            return this.repo.GetAll(filter);
        }
    }
}
