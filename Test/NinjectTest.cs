using Es.Udc.DotNet.SudokuApp.Model;
using Es.Udc.DotNet.SudokuApp.ModelUsersDao;
using Es.Udc.DotNet.SudokuApp.Test;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Microsoft.Analytics.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Es.Udc.DotNet.SudokuApp.Test
{
    [TestClass]
    public class NinjectTest
    {
        private static IKernel kernel;
        private static IUsersDao userDao;
        private static Users user;

        // Variables used in several tests are initialized here
        private const String userName = "pseudonimTest";

        private const String clearPassword = "password";
        private const String firstname = "name";
        private const String lastname = "lastName";
        private const String email = "user@udc.es";
        private const String idiom = "es";
        private const String country = "ES";
        private const long NON_EXISTENT_USER_ID = -1;

        private TransactionScope transaction;

        private TestContext testContextInstance;


        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();
            userDao = kernel.Get<IUsersDao>();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            transaction.Dispose();
        }


        [TestMethod()]
        public void NinjectTestMethod()
        {

            kernel = TestManager.ConfigureNInjectKernel();


            IUsersDao dao = kernel.Get<IUsersDao>();

            Assert.IsInstanceOfType(dao, typeof(IUsersDao));

        }
    }
}
