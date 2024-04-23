using Ninject;
using SudokuApp.UsersDao;
using SudokuApp.UsuarioDao;
using SudokuApp.UsuarioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.UserService
{
    public interface IUserService
    {
        [Inject]
        IUsersDao UsersDao { set; }




        LoginResult Login(String userName, String password,Boolean passwordIsEncrypted);


        long RegisterUser(String userName, String clearPassword, UserDetails userDetails);

        UserDetails FindUserDetails(long usrId);


        void UpdateUserProfileDetails(long usrId, UserDetails userDetails);


        void ChangePassword(long usrId, string oldps, string newps);


        bool UserExists(string userName);

    }
}
