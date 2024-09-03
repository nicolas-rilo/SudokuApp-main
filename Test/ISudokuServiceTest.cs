using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Es.Udc.DotNet.SudokuApp.Model;
using Es.Udc.DotNet.SudokuApp.Model.ReviewDao;
using Es.Udc.DotNet.SudokuApp.Model.SudokuDao;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Model.UserService;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioService;
using Es.Udc.DotNet.SudokuApp.ModelUsersDao;
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
        private static IUsersDao usersDao;
        private static ISudokuDao sudokuDao;
        private static IReviewDao reviewDao;



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
            sudokuDao = kernel.Get<ISudokuDao>();
            usersDao = kernel.Get<IUsersDao>();
            reviewDao = kernel.Get<IReviewDao>();
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
                    new UserDetails(firstName, lastName, email, idiom, country));

                SudokuDto sudokuDto = new SudokuDto(-1,usrId,"sudoku1","no rules","easy",true,false,
                    false,false,false, matriz1, matrizSolution);

                sudokuService.uploadSudoku(sudokuDto);

                List<SudokuDto> sudokuDtos = sudokuService.findByUser(usrId,0,1);

                SudokuDto sudokuDto1 = sudokuDtos.First();

                Assert.AreEqual(sudokuDto1.name, "sudoku1");
                Assert.AreEqual(sudokuDto1.rules, "no rules");
                Assert.AreEqual(sudokuDto1.dificulty, "easy");
                Assert.AreEqual(sudokuDto1.nomal, true);
                Assert.AreEqual(sudokuDto1.killer, false);
                Assert.AreEqual(sudokuDto1.puzzle[0,0], matriz1[0,0]);
                Assert.AreEqual(sudokuDto1.puzzle[0, 1], matriz1[0, 1]);
                Assert.AreEqual(sudokuDto1.puzzle[0, 2], matriz1[0, 2]);

                Assert.AreEqual(sudokuDto1.solution[0, 0], matrizSolution[0, 0]);
                Assert.AreEqual(sudokuDto1.solution[0, 1], matrizSolution[0, 1]);
                Assert.AreEqual(sudokuDto1.solution[0, 2], matrizSolution[0, 2]);
            }
        }



        [TestMethod]
        public void TestReviews()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                long usrId = userService.RegisterUser(userName, clearPassword,
                        new UserDetails(firstName, lastName, email, idiom, country));

                long usrId1 = userService.RegisterUser("aa", "bb",
                        new UserDetails(firstName1, lastName1, email1, idiom1, country1));


                SudokuDto sudokuDto = new SudokuDto(-1,usrId, "sudoku1", "no rules", "easy", true, false,
                    false, false, false, matriz1, matrizSolution);

               long sudokuId = sudokuService.uploadSudoku(sudokuDto);


                sudokuService.reviewSudoku(sudokuId, usrId, 5);
                sudokuService.reviewSudoku(sudokuId, usrId1, 4);

                List<Review> reviews = sudokuService.GetReviews(sudokuId,0,2);

                Assert.AreEqual(reviews.First().review_value, 5);

                Assert.AreEqual(sudokuService.getAverageReview(sudokuId), 4);
            }
        }

        [TestMethod]

        public void CreateArrow()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                long usrId = userService.RegisterUser(userName, clearPassword,
                    new UserDetails(firstName, lastName, email, idiom, country));

                SudokuDto sudokuDto = new SudokuDto(-1,usrId, "sudoku1", "no rules", "easy", true, false,
                    false, false, false, matriz1, matrizSolution);

                long sudokuId = sudokuService.uploadSudoku(sudokuDto);

                List<(int, int)> ps = new List<(int, int)>();

                ps.Add((1, 2));
                ps.Add((1, 3));
                ps.Add((1, 4));

                sudokuService.createArrow(sudokuId, (1, 1), (1, 5), ps);
                sudokuService.createArrow(sudokuId, (9, 1), (9, 9), ps);


                List<ArrowDto> arrowDtos = sudokuService.getSudokuArrows(sudokuId);

                Assert.AreEqual(arrowDtos[0].startCell, (1, 1));
                Assert.AreEqual(arrowDtos[0].endCell, (1, 5));

                Assert.AreEqual(arrowDtos[0].cells[0], (1, 2));
                Assert.AreEqual(arrowDtos[0].cells[1], (1, 3));

                Assert.AreEqual(arrowDtos[1].startCell, (9, 1));
                Assert.AreEqual(arrowDtos[1].endCell, (9, 9));

            }
        }


        [TestMethod]

        public void CreateKillerBox()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                long usrId = userService.RegisterUser(userName, clearPassword,
                        new UserDetails(firstName, lastName, email, idiom, country));

                SudokuDto sudokuDto = new SudokuDto(-1,usrId, "sudoku1", "no rules", "easy", true, false,
                    false, false, false, matriz1, matrizSolution);

                long sudokuId = sudokuService.uploadSudoku(sudokuDto);

                List<(int, int)> ps = new List<(int, int)>();

                ps.Add((1, 2));
                ps.Add((2, 2));
                ps.Add((1, 3));
                ps.Add((2, 3));
                ps.Add((1, 4));

                sudokuService.createKillerBox(sudokuId,15,ps);

                List<KillerBoxDto> killerBoxDtos = sudokuService.getSudokuKillerBox(sudokuId);

                Assert.AreEqual(killerBoxDtos[0].value, 15);
                Assert.AreEqual(killerBoxDtos[0].cells[0],(1,2));
                Assert.AreEqual(killerBoxDtos[0].cells[1], (2, 2));


            }
        }

        [TestMethod]

        public void CreateThermo()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                long usrId = userService.RegisterUser(userName, clearPassword,
                    new UserDetails(firstName, lastName, email, idiom, country));

                SudokuDto sudokuDto = new SudokuDto(-1,usrId, "sudoku1", "no rules", "easy", true, false,
                    false, false, false, matriz1, matrizSolution);

                long sudokuId = sudokuService.uploadSudoku(sudokuDto);

                List<(int, int)> ps = new List<(int, int)>();

                ps.Add((1, 2));
                ps.Add((1, 3));
                ps.Add((1, 4));

                sudokuService.createThermo(sudokuId, (1, 1), (1, 5), ps);
                sudokuService.createThermo(sudokuId, (9, 1), (9, 9), ps);


                List<ThermoDto> thermoDtos = sudokuService.getSudokuThermos(sudokuId);

                Assert.AreEqual(thermoDtos[0].startCell, (1, 1));
                Assert.AreEqual(thermoDtos[0].endCell, (1, 5));

                Assert.AreEqual(thermoDtos[0].cells[0], (1, 2));
                Assert.AreEqual(thermoDtos[0].cells[1], (1, 3));

                Assert.AreEqual(thermoDtos[1].startCell, (9, 1));
                Assert.AreEqual(thermoDtos[1].endCell, (9, 9));

            }
        }



        [TestMethod]

        public void GenerateSudoku()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                SudokuDto generated = sudokuService.generateSudoku(0);

                Assert.AreEqual(generated.dificulty,"Easy");

               // printMatrix(generated.puzzle);
               // printMatrix(generated.solution);


            }
        }

        /*private void printMatrix(int[,] arr) {

            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }*/

    }
}
