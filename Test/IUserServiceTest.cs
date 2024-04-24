using Es.Udc.DotNet.SudokuApp.Model;
using Es.Udc.DotNet.SudokuApp.Model.UserService;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioService;
using Es.Udc.DotNet.SudokuApp.Model.Util;
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
    public class IUserServiceTest
    {
        private const string userName = "userName";
        private const string clearPassword = "password";

        private const string firstName = "name";
        private const string firstName1 = "name1";
        private const string lastName = "lastName";
        private const string lastName1 = "lastName1";
        private const string email = "user@udc.es";
        private const string email1 = "user1@udc.es";
        private const string idiom = "es";
        private const string country = "ES";
        private const long NON_EXISTENT_USER_ID = -1;
        private const string NON_EXISTENT_PASS = "nopasswd";
        private const string NON_EXISTENT_PSEUDONIM = "pseudo";
        private static IKernel kernel;
        private static IUserService userService;
        private static IUsersDao usersDao;
        

        private TransactionScope transactionScope;

        public TestContext TestContext { get; set; }


        [TestInitialize()]
        public void MyTestInitialize()
        {
            transactionScope = new TransactionScope();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel(); 
            usersDao = kernel.Get<IUsersDao>();
            userService = kernel.Get<IUserService>();

        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        [TestMethod]
        public void TestRegisterUser()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                long userId = userService.RegisterUser(userName, clearPassword,
                        new UserDetails(firstName, lastName, email, idiom, country,true));

                Users usuario = usersDao.Find(userId);

                Assert.AreEqual(userId, usuario.usrId);
                Assert.AreEqual(userName, usuario.userName);
                Assert.AreEqual(PasswordEncrypter.Crypt(clearPassword), usuario.password);
                Assert.AreEqual(firstName, usuario.firstName);
                Assert.AreEqual(lastName, usuario.lastName);
                Assert.AreEqual(email, usuario.email);
                Assert.AreEqual(idiom, usuario.idiom);
                Assert.AreEqual(country, usuario.country);
                Assert.AreEqual(true, usuario.admin);
            }
        }
    
    }


}
