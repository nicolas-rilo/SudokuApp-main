using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Es.Udc.DotNet.SudokuApp.Model;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Model.UserService;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Test
{
    [TestClass]

    public class ISudokuServiceTest
    {
        private TransactionScope transanctionScope;
        private static IKernel kernel;
        private static IUserService userService;
        private static ISudokuService sudokuService;

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

        private int[,] matriz1 = {
            { 8, 7, 6, 0, 1, 0, 3, 9, 2 },
            { 0, 2, 9, 0, 7, 0, 0, 5, 0 },
            { 4, 0, 5, 2, 9, 0, 7, 0, 8 },
            { 7, 4, 1, 5, 6, 0, 0, 0, 3 },
            { 5, 0, 2, 0, 0, 4, 0, 6, 1 },
            { 0, 0, 3, 1, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 4, 2, 0 },
            { 0, 5, 4, 0, 0, 8, 0, 3, 7 },
            { 2, 9, 0, 0, 4, 1, 6, 8, 0 }
        };

        private int[,] matrizSolution = {
            { 8, 7, 6, 4, 1, 5, 3, 9, 2 },
            { 1, 2, 9, 8, 7, 3, 4, 5, 6 },
            { 4, 3, 5, 2, 9, 6, 7, 1, 8 },
            { 7, 4, 1, 5, 6, 9, 8, 2, 3 },
            { 5, 8, 2, 7, 3, 4, 9, 6, 1 },
            { 9, 6, 3, 1, 8, 2, 5, 7, 4 },
            { 3, 1, 8, 6, 5, 7, 4, 2, 9 },
            { 6, 5, 4, 9, 1, 8, 1, 3, 7 },
            { 2, 9, 7, 3, 4, 1, 6, 8, 5 }
        };

        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            transanctionScope = new TransactionScope();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            transanctionScope.Dispose();
        }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();
            userService = kernel.Get<IUserService>();
            sudokuService = kernel.Get<ISudokuService>();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        [TestMethod]
        public void TestCreateSudoku()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                long usrId = userService.RegisterUser(userName, clearPassword,
                    new UserDetails(firstName, lastName, email, idiom, country, true));

                SudokuDto sudokuDto = new SudokuDto(usrId,"sudoku1","no rules","easy",true,false,
                    false,false,false, matriz1, matrizSolution);

                sudokuService.uploadSudoku(sudokuDto);
            }
        }
    }
}
