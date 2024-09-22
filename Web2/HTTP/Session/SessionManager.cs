using System;
using System.Collections.Generic;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.IoC;
using System.Web;
using Es.Udc.DotNet.SudokuApp.Model.UserService;
using Es.Udc.DotNet.SudokuApp.Model.TournamentService;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioService;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.View;
using System.Web.Security;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioDao;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Util;
using Es.Udc.DotNet.SudokuApp.Model;
using Es.Udc.DotNet.SudokuApp.Model.TournamentDao;

namespace Es.Udc.DotNet.SudokuApp.Web.HTTP.Session
{
    public class SessionManager
    {
        public static readonly String LOCALE_SESSION_ATTRIBUTE = "locale";

        public static readonly String USER_SESSION_ATTRIBUTE =
               "userSession";

        private static IUserService userService;
        private static ITournamentService tournamenService;
        private static ISudokuService sudokuService;
        private static SudokuDto sudokuDto;



        public IUserService UserService
        {
            set { userService = value; }
        }

        public ITournamentService TournamentService
        {
            set { tournamenService = value; }
        }
        public ISudokuService SudokuService
        {
            set { sudokuService = value; }
        }

        static SessionManager()
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];

            userService = iocManager.Resolve<IUserService>();
            tournamenService = iocManager.Resolve<ITournamentService>();
            sudokuService = iocManager.Resolve<ISudokuService>();
        }
        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="loginName">Username</param>
        /// <param name="clearPassword">Password in clear text</param>
        /// <param name="userProfileDetails">The user profile details.</param>
        /// <exception cref="DuplicateInstanceException"/>
        public static void RegisterUser(HttpContext context,
            String loginName, String clearPassword,
            UserDetails userProfileDetails)
        {
            long usrId = userService.RegisterUser(loginName, clearPassword,
                            userProfileDetails);

            /* Insert necessary objects in the session. */
            UserSession userSession = new UserSession();
            userSession.UserProfileId = usrId;
            userSession.Firstname = userProfileDetails.firstName;

            Locale locale = new Locale(userProfileDetails.idiom,
                userProfileDetails.country);

            UpdateSessionForAuthenticatedUser(context, userSession, locale);
            FormsAuthentication.SetAuthCookie(loginName, false);
        }

        /// <summary>
        /// Login method. Authenticates an user in the current context.
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="loginName">Username</param>
        /// <param name="clearPassword">Password in clear text</param>
        /// <param name="rememberMyPassword">Remember password to the next logins</param>
        /// <exception cref="IncorrectPasswordException"/>
        /// <exception cref="InstanceNotFoundException"/>
        public static void Login(HttpContext context, String loginName,
           String clearPassword, Boolean rememberMyPassword)
        {
            /* Try to login, and if successful, update session with the necessary
             * objects for an authenticated user. */
            LoginResult loginResult = DoLogin(context, loginName,
                clearPassword, false, rememberMyPassword);

            /* Add cookies if requested. */
            if (rememberMyPassword)
            {
                CookiesManager.LeaveCookies(context, loginName,
                    loginResult.EncryptedPassword);
            }
        }



        /// <summary>
        /// Tries to log in with the corresponding method of
        /// <c>UserService</c>, and if successful, inserts in the
        /// session the necessary objects for an authenticated user.
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="loginName">Login name</param>
        /// <param name="password">User Password</param>
        /// <param name="passwordIsEncrypted">Password is either encrypted or
        /// in clear text</param>
        /// <param name="rememberMyPassword">Remember password to the next
        /// logins</param>
        /// <exception cref="IncorrectPasswordException"/>
        /// <exception cref="InstanceNotFoundException"/>
        private static LoginResult DoLogin(HttpContext context,
             String loginName, String password, Boolean passwordIsEncrypted,
             Boolean rememberMyPassword)
        {
            LoginResult loginResult =
                userService.Login(loginName, password,
                    passwordIsEncrypted);

            /* Insert necessary objects in the session. */

            UserSession userSession = new UserSession();
            userSession.UserProfileId = loginResult.UserId;
            userSession.Firstname = loginResult.Name;

            Locale locale =
                new Locale(loginResult.Idiom, loginResult.Country);

            UpdateSessionForAuthenticatedUser(context, userSession, locale);

            return loginResult;
        }

        public static void ChecPass(HttpContext context, String loginName, String clearPassword)
        {
            LoginResult loginResult =
                 userService.Login(loginName, clearPassword,
                     false);

        }
        /// <summary>
        /// Updates the session values for an previously authenticated user
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="userSession">The user data stored in session.</param>
        /// <param name="locale">The locale info.</param>
        private static void UpdateSessionForAuthenticatedUser(
            HttpContext context, UserSession userSession, Locale locale)
        {
            /* Insert objects in session. */
            context.Session.Add(USER_SESSION_ATTRIBUTE, userSession);
            context.Session.Add(LOCALE_SESSION_ATTRIBUTE, locale);
        }

        /// <summary>
        /// Checks if an user is authenticated
        /// </summary>
        /// <param name="context">Http Context (request, response ...)</param>
        /// <returns>
        /// 	<c>true</c> if is user authenticated
        ///     <c>false</c> otherwise
        /// </returns>
        public static Boolean IsUserAuthenticated(HttpContext context)
        {
            if (context.Session == null)
                return false;

            return (context.Session[USER_SESSION_ATTRIBUTE] != null);
        }

        public static Locale GetLocale(HttpContext context)
        {
            Locale locale =
                (Locale)context.Session[LOCALE_SESSION_ATTRIBUTE];

            return locale;
        }

        /// <summary>
        /// Updates the user profile details.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userProfileDetails">The user profile details.</param>
        public static void UpdateUserProfileDetails(HttpContext context,
            UserDetails userProfileDetails)
        {
            /* Update user's profile details. */

            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            userService.UpdateUserProfileDetails(userSession.UserProfileId,
                userProfileDetails);

            /* Update user's session objects. */

            Locale locale = new Locale(userProfileDetails.idiom,
                userProfileDetails.country);

            userSession.Firstname = userProfileDetails.firstName;

            UpdateSessionForAuthenticatedUser(context, userSession, locale);
        }

        /// <summary>
        /// Finds the user profile with the id stored in the session.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static UserDetails FindUserDetails(HttpContext context)
        {
            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            UserDetails userProfileDetails =
                userService.FindUserDetails(userSession.UserProfileId);

            return userProfileDetails;
        }

        /// <summary>
        /// Gets the user info stored in the session.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static UserSession GetUserSession(HttpContext context)
        {
            if (IsUserAuthenticated(context))
                return (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            else
                return null;
        }

        /// <summary>
        /// Changes the user's password
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="oldClearPassword">The old password in clear text</param>
        /// <param name="newClearPassword">The new password in clear text</param>
        /// <exception cref="IncorrectPasswordException"/>
        public static void ChangePassword(HttpContext context,
               String oldClearPassword, String newClearPassword)
        {
            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            userService.ChangePassword(userSession.UserProfileId,
                oldClearPassword, newClearPassword);

            /* Remove cookies. */
            CookiesManager.RemoveCookies(context);
        }

        /// <summary>
        /// Destroys the session, and removes the cookies if the user had
        /// selected "remember my password".
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        public static void Logout(HttpContext context)
        {
            /* Remove cookies. */
            CookiesManager.RemoveCookies(context);

            /* Invalidate session. */
            context.Session.Abandon();

            /* Invalidate Authentication Ticket */
            FormsAuthentication.SignOut();
        }

        /// <sumary>
        /// Guarantees that the session will have the necessary objects if the
        /// user has been authenticated or had selected "remember my password"
        /// in the past.
        /// </sumary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        public static void TouchSession(HttpContext context)
        {
            /* Check if "UserSession" object is in the session. */
            UserSession userSession = null;

            if (context.Session != null)
            {
                userSession =
                    (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

                // If userSession object is in the session, nothing should be doing.
                if (userSession != null)
                {
                    return;
                }
            }

            /*
             * The user had not been authenticated or his/her session has
             * expired. We need to check if the user has selected "remember my
             * password" in the last login (login name and password will come
             * as cookies). If so, we reconstruct user's session objects.
             */
            UpdateSessionFromCookies(context);
        }

        /// <summary>
        /// Tries to login (inserting necessary objects in the session) by using
        /// cookies (if present).
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        private static void UpdateSessionFromCookies(HttpContext context)
        {
            HttpRequest request = context.Request;
            if (request.Cookies == null)
            {
                return;
            }

            /*
             * Check if the login name and the encrypted password come as
             * cookies.
             */
            String loginName = CookiesManager.GetLoginName(context);
            String encryptedPassword = CookiesManager.GetEncryptedPassword(context);

            if ((loginName == null) || (encryptedPassword == null))
            {
                return;
            }

            /* If loginName and encryptedPassword have valid values (the user selected "remember
             * my password" option) try to login, and if successful, update session with the
             * necessary objects for an authenticated user.
             */
            try
            {
                DoLogin(context, loginName, encryptedPassword, true, true);

                /* Authentication Ticket. */
                FormsAuthentication.SetAuthCookie(loginName, true);
            }
            catch (Exception)
            { // Incorrect loginName or encryptedPassword
                return;
            }
        }

        public static long uploadSudoku(HttpContext context, string name, string rules, string dificulty
            , bool normal, bool killer, bool thermal, bool arrow, bool custom, int[,] puzzle, int[,] solution, int[,] image) {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];



            SudokuDto sudokuDto = new SudokuDto(0, userSession.UserProfileId, name, rules, dificulty,
                normal, killer, thermal, arrow, custom, puzzle, solution, image);
            return sudokuService.uploadSudoku(sudokuDto);
        }

        public static SudokuDto generateSudoku(HttpContext context, int dificulty) {
            return sudokuService.generateSudoku(dificulty);
        }

        public static List<SudokuDto> findByFilter(HttpContext context, string name, string dificulty, bool normal, bool killer, bool thermal
            , bool arrow, bool custom, int start, int size) {

            return sudokuService.findByFilter(name, dificulty, normal, killer, thermal, arrow, custom, start, size);
        }
        public static bool isUserAdmin(HttpContext context) {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            return userService.IsUserAdmin(userSession.UserProfileId);
        }

        public static void createTournament(HttpContext context, long sudokuId, DateTime start, DateTime end) {

            tournamenService.createTournament(sudokuId, start, end);
        }

        public static List<SudokuDto> findSudoku(HttpContext context, long sudokuId) {
            return sudokuService.findSudoku(sudokuId);
        }

        public static List<TournamentDto> getActiveTournaments(HttpContext context){
            return tournamenService.getActiveTournaments();
        }

        public static void participate(HttpContext context, long tournamentId, TimeSpan timeSpan) {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            tournamenService.participateInTournament(userSession.UserProfileId, tournamentId,timeSpan);
        }
        public static TournamentDto getTournament(HttpContext context, long tournamentId) {

            return tournamenService.getTournament(tournamentId);
        }

        public static List<ParticipationDto> getRanking(HttpContext context, long tournamentId,int start, int skip ) {
            return tournamenService.getRanking(tournamentId, start, skip);
        }

        public static ParticipationDto getUserPosition(HttpContext context, long tournamentId) {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            return tournamenService.getUserRank(userSession.UserProfileId,tournamentId);
        }

        public static List<ThermoDto> getThermos(HttpContext context, long sudokuId) {

            return sudokuService.getSudokuThermos(sudokuId);
        }
        public static void uploadThermo(HttpContext context, long sudokuId,(int,int) startCell, (int,int) endCell, List<(int,int)> ps)
        {

             sudokuService.createThermo(sudokuId,startCell,endCell,ps);
        }
        public static List<SudokuDto> findSudokusByUser(HttpContext context, int start, int size) {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];


            return sudokuService.findByUser(userSession.UserProfileId, start, size);
        }
        public static void reviewSudoku(HttpContext context,long sudokuId, int review) {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            sudokuService.reviewSudoku(sudokuId, userSession.UserProfileId, review);
        }
        public static int averageReview(HttpContext context, long sudokuId) {
            return sudokuService.getAverageReview(sudokuId);
            
        }

    }

}