using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.SudokuApp.Model.ArrowDao;
using Es.Udc.DotNet.SudokuApp.Model.CellDao;
using Es.Udc.DotNet.SudokuApp.Model.KillerDao;
using Es.Udc.DotNet.SudokuApp.Model.ParticipantDao;
using Es.Udc.DotNet.SudokuApp.Model.ReviewDao;
using Es.Udc.DotNet.SudokuApp.Model.SudokuDao;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Model.ThermoDao;
using Es.Udc.DotNet.SudokuApp.Model.TournamentDao;
using Es.Udc.DotNet.SudokuApp.Model.TournamentService;
using Es.Udc.DotNet.SudokuApp.Model.UserService;
using Es.Udc.DotNet.SudokuApp.ModelUsersDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Test
{
    public class TestManager
    {

        public static IKernel ConfigureNInjectKernel()
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };

            IKernel kernel = new StandardKernel(settings);

            kernel.Bind<IUsersDao>().
                To<UserDaoEntityFramework>();

            kernel.Bind<IUserService>().
                To<UserService>();

            kernel.Bind<ISudokuDao>().
                To<SudokuDaoEntityFramework>();

            kernel.Bind<ISudokuService>().
                To<SudokuService>();

            kernel.Bind<ICellDao>()
                .To<CellDaoEntityFramework>();

            kernel.Bind<IReviewDao>()   
                .To<ReviewDaoEntityFramework>();

            kernel.Bind<ITournamentService>()
                .To<TournamentService>();

            kernel.Bind<ITournamentDao>()
                .To<TournamentDaoEntityFramework>();

            kernel.Bind<IParticipantDao>()
                .To<ParticipantDaoEntityFramework>();

            kernel.Bind<IArrowDao>()
                .To<ArrowDaoEntityFramework>();
            kernel.Bind<IKillerBoxDao>()
                .To<KillerBoxDaoEntityFramework>();
            kernel.Bind<IThermoDao>()
                .To<ThermoDaoEntityFramework>();

            string connectionString =
                ConfigurationManager.ConnectionStrings["sudokuApp"].ConnectionString; 

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);

            return kernel;
        }

        public static IKernel ConfigureNInjectKernel(string moduleFilename)
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };
            IKernel kernel = new StandardKernel(settings);

            kernel.Load(moduleFilename);

            return kernel;
        }

        public static void ClearNInjectKernel(IKernel kernel)
        {
            kernel.Dispose();
        }
    }
}
