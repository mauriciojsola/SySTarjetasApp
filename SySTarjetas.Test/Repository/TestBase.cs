using System;
using System.Configuration;
using System.IO;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SySTarjetas.Core.Repository;
using SySTarjetas.Test.Properties;

namespace SySTarjetas.Test.Repository
{
    [TestClass]
    public class TestBase
    {
        private static readonly object syncRoot = new object();
        protected static IContainer Container;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            //Configure Repository
            var container = new ContainerBuilder();
            container.RegisterModule(new RepositoryIoCModule { IsWebContext = false, ConnectionStringName = "SySTarjetasEntitiesTest" });
            Container = container.Build();

            EnsureTestDatabase();
        }

        private static void EnsureTestDatabase()
        {
            var commonAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dbPath = Path.Combine(commonAppFolder, "SySTarjetasTest.sdf");

            if (!File.Exists(dbPath))
            {
                File.WriteAllBytes(dbPath, Resources.SySTarjetasTestDb);
            }

            // Need to fix the connection string with the current default commonAppFolder 
            UpdateConnectionString(commonAppFolder);
        }

        private static void UpdateConnectionString(string commonAppFolder)
        {
            var cm = ConfigurationManager.ConnectionStrings["SySTarjetasEntitiesTest"];
            var newConn = cm.ConnectionString.Replace("|ApplicationData|", commonAppFolder);

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["SySTarjetasEntitiesTest"].ConnectionString = newConn;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        [TestInitialize]
        public virtual void TestInitialize()
        {

        }

        [TestCleanup]
        public virtual void TestCleanup()
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Container.Dispose();
        }

    }
}
