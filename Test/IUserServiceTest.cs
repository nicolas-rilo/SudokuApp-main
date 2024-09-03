using Es.Udc.DotNet.SudokuApp.Model;
using Es.Udc.DotNet.SudokuApp.Model.UserService;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioDao;
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
        private const string idiom1 = "EN";
        private const string country1 = "US";
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
                        new UserDetails(firstName, lastName, email, idiom, country));

                Users usuario = usersDao.Find(userId);

                Assert.AreEqual(userId, usuario.usrId);
                Assert.AreEqual(userName, usuario.userName);
                Assert.AreEqual(PasswordEncrypter.Crypt(clearPassword), usuario.password);
                Assert.AreEqual(firstName, usuario.firstName);
                Assert.AreEqual(lastName, usuario.lastName);
                Assert.AreEqual(email, usuario.email);
                Assert.AreEqual(idiom, usuario.idiom);
                Assert.AreEqual(country, usuario.country);
                Assert.AreEqual(false, usuario.admin);
            }
        }

        [TestMethod]
        public void TestUsuarioExists()
        {
            using (var scope = new TransactionScope())
            {
                userService.RegisterUser(userName, clearPassword,
                   new UserDetails(firstName, lastName, email, idiom, country));
                bool existe = userService.UserExists(userName);
                Assert.IsTrue(existe);
            }
        }


        [TestMethod]
        public void TestLoginUser()
        {
            using (var scope = new TransactionScope())
            {
                long usrId = userService.RegisterUser(userName, clearPassword,
                    new UserDetails(firstName, lastName, email, idiom, country));

                Users user = usersDao.Find(usrId);
                LoginResult result = userService.Login(user.userName, clearPassword, false);

                Assert.AreEqual(result.UserId, usrId);
                Assert.AreEqual(result.Name, user.firstName);
                Assert.AreEqual(result.Idiom, user.idiom);
                Assert.AreEqual(result.Country, user.country);
                Assert.AreEqual(result.EncryptedPassword, user.password);
            }

        }

        [TestMethod]
        public void TestUpdateUserDetails()
        {
            using (var scope = new TransactionScope())
            {
                long usrId = userService.RegisterUser(userName, clearPassword, new UserDetails(firstName, lastName, email, idiom, country));

                Users usuario = usersDao.Find(usrId);

                userService.UpdateUserProfileDetails(usrId, new UserDetails(firstName1, lastName1, email1, idiom1, country1));

                Users usuarioUpdated = usersDao.Find(usrId);

                Assert.AreEqual(usuario, usuarioUpdated);
                Assert.AreEqual(firstName1, usuarioUpdated.firstName);
                Assert.AreEqual(lastName1, usuarioUpdated.lastName);
                Assert.AreEqual(email1, usuarioUpdated.email);
                Assert.AreEqual(idiom1, usuarioUpdated.idiom);
                Assert.AreEqual(country1, usuarioUpdated.country);
                Assert.AreEqual(false, usuarioUpdated.admin);
            }
        }

        [TestMethod]
        public void TestFindDetails()
        {
            using (var scope = new TransactionScope())
            {
                long usrId = userService.RegisterUser(userName, clearPassword, new UserDetails(firstName, lastName, email, idiom, country));

                UserDetails details = userService.FindUserDetails(usrId);

                Assert.AreEqual(firstName, details.firstName);
                Assert.AreEqual(lastName, details.lastName);
                Assert.AreEqual(email, details.Email);
                Assert.AreEqual(idiom, details.idiom);
                Assert.AreEqual(country, details.country);

            }
        }

    }


}
