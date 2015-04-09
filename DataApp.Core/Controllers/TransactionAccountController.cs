using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApp.Core.Abstracts;
using DataApp.Core.DAL;
using DataApp.Core.Models;
namespace DataApp.Core.Controllers
{
    public class TransactionAccountController : Controller<TransactionAccount>, IAddData<TransactionAccount>//, IReadData<TransactionAccount>, IModifyData<TransactionAccount>
    {
        public TransactionAccountController(DataAppContext dbContext)
            :base(dbContext)
        {
        }

        public bool Add(TransactionAccount entity)
        {
            return this.repo.Add(entity);
        }

        public bool Update(TransactionAccount entity)
        {
            return this.repo.Update(entity);
        }

        public TransactionAccount Get(object id)
        {
            return this.repo.Get(id);
        }

        public List<TransactionAccount> GetAll(Func<TransactionAccount, bool> filter = null)
        {
            return this.repo.Get(filter);
        }
    }
}
