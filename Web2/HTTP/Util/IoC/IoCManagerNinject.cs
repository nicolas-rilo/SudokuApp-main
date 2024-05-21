using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Es.Udc.DotNet.ModelUtil.IoC;
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
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Web.HTTP.Util.IoC
{

    public class IoCManagerNinject : IIoCManager
    {
        private static IKernel kernel;
        private static NinjectSettings settings;
        public void Configure()
        {
            settings = new NinjectSettings() { LoadExtensions = true };
            kernel = new StandardKernel(settings);

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
        }

        public T Resolve<T>()
        {
            return kernel.Get<T>();
        }
    }
}