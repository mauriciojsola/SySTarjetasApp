using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SySTarjetas.Core;
using SySTarjetas.Core.Repository;

namespace SySTarjetas.Test.Repository
{
    [TestClass]
    public class ComercioRepositoryTests : RepositoryTestBase<IComercioRepository>
    {
        [TestMethod]
        public void TestGetComercio()
        {
            Comercio comercio = null;
            var name = DateTime.Now.ToLongTimeString();

            InUnitOfWork(() =>
            {
                var c1 = Repository.GetById(1);
                c1.RazonSocial = name;
            });

            InUnitOfWork(() =>
            {
                comercio = Repository.GetById(1);
            });

            Assert.AreEqual(name, comercio.RazonSocial);
        }

    }
}
