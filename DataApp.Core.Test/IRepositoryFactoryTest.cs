using DataApp.Core.Abstracts;
using DataApp.Core.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataApp.Core.Test
{
    [TestClass]
    public class IRepositoryFactoryTest
    {
        IRepositoryFactory target = null;
        DataAppContext dbContext = null;

        [TestMethod]
        public void CreateRepository()
        {
            //arrage
            DataApp.Core.Abstracts.IRepository<DataApp.Core.Models.User> repo = null;
            this.dbContext = new DAL.DataAppContext();
            this.target = new DataApp.Core.Factories.RepoFactory();

            //act
            repo = this.target.CreateRepository<DataApp.Core.Models.User>(this.dbContext);

            //assert
            Assert.IsNotNull(repo);
        }
    }
}
