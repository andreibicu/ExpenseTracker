using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataApp.Core.Abstracts;
using DataApp.Core.DAL;
using DataApp.Core.Models;
using System.Collections.Generic;
namespace DataApp.Core.Test
{
    [TestClass]
    public class IRepositoryTest
    {
        IRepositoryFactory factory = null;
        DataAppContext dbContext = null;
        IRepository<Project> target = null;

        [TestInitialize]
        public void Init()
        {
            this.dbContext = new DAL.DataAppContext();
            this.factory = new DataApp.Core.Factories.RepoFactory();
            this.target = this.factory.CreateRepository<Project>(this.dbContext);
        }

        [TestMethod]
        public void Add()
        {
            //arrange
            Project project = new Project();
            project.Name = "test";

            //act
            
            //assert
            Assert.IsTrue(this.target.Add(project));
        }

        [TestMethod]
        public void Update()
        {
            //arrange
            Project project = new Project();

            //act
            this.target.Add(project);
            project.Name = "Update";

            //assert
            Assert.IsTrue(this.target.Update(project));
        }

        [TestMethod]
        public void Delete()
        {
            //arrange
            Project project = new Project();
            project.Name = "To Be Deleted";

            //act
            this.target.Add(project);

            //assert
            Assert.IsTrue(this.target.Update(project));
        }

        [TestMethod]
        public void Get()
        {
            //arrange
            Project project = null;

            //act
            project = this.target.Get(p => p.ID > 0); 

            //assert
            Assert.IsNotNull(project);
        }

        [TestMethod]
        public void GetAll()
        {
            //arrange
            List<Project> projects = null;

            //act
            projects = this.target.GetAll();

            //assert
            Assert.IsNotNull(projects);
        }
    }
}
