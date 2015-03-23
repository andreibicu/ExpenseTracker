using DataApp.Core.Abstracts;
using DataApp.Core.Models;

namespace DataApp.Core.Controllers
{
    public class UserController : Controller<User> 
    {

        #region IUserController Members

        public Models.User Login(string username, string password)
        {
            User user = null;

            user = this.repo.Get(u => u.Username == username && u.Password == password);

            return user;
        }

        #endregion

        #region IAddData<User> Members

        public bool Add(Models.User entity)
        {
            return this.repo.Add(entity);
        }

        #endregion

        #region IModifyData<User> Members

        public bool Update(Models.User entity)
        {
            return this.repo.Update(entity); 
        }

        #endregion
    }
}
