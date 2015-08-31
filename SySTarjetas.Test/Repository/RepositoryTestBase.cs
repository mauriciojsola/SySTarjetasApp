using System;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SySTarjetas.Core.Infrastructure.Persistence;
using SySTarjetas.Core.Repository;

namespace SySTarjetas.Test.Repository
{
    [TestClass]
    public class RepositoryTestBase<T> : TestBase where T  : IRepository
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
        public T Repository { get; set; }
        
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Container.InjectProperties(this);
            UnitOfWorkProvider = Container.Resolve<IUnitOfWorkProvider>();
            Repository = Container.Resolve<T>();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        protected void InUnitOfWork(Action action)
        {
            using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
            {
                action();
                uow.Commit();
            }
        }

    }
}
