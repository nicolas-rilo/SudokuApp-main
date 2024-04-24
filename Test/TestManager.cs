using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.SudokuApp.Model.UserService;
using Es.Udc.DotNet.SudokuApp.ModelUsersDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Test
{
    public class TestManager
    {
        private static IKernel kernel;
        private static IUserService userService;

        public TestContext TestContext { get; set; }

        public static IKernel ConfigureNInjectKernel()
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };

            IKernel kernel = new StandardKernel(settings);

            kernel.Bind<IUsersDao>().
                To<UserDaoEntityFramework>();

            string connectionString =
                ConfigurationManager.ConnectionStrings["sudokuApp"].ConnectionString; 

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);

            return kernel;
        }

        internal static void ClearNInjectKernel(IKernel kernel)
        {
            throw new NotImplementedException();
        }
    }
}
