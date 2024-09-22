using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.SudokuApp.Model.Exceptions;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioDao;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioService;
using Es.Udc.DotNet.SudokuApp.Model.Util;
using Es.Udc.DotNet.SudokuApp.ModelUsersDao;
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Model.UserService
{
    public class UserService : IUserService
    {
        [Inject]
        public IUsersDao UsersDao { private get; set; }

        public LoginResult Login(string userName, string password, bool passwordIsEncrypted)
        {
            Users user=UsersDao.FindByUserName(userName);

            String storedPassword = user.password;

            if (passwordIsEncrypted)
            {
                if (!password.Equals(storedPassword))
                {
                    throw new IncorrectPasswordException(userName);
                }
            }
            else
            {
                if (!PasswordEncrypter.IsClearPasswordCorrect(password,
                        storedPassword))
                {
                    throw new IncorrectPasswordException(userName);
                }
            }

            return new LoginResult(user.usrId, user.firstName, storedPassword, user.idiom, user.country);
        }
        public long RegisterUser(string userName, string clearPassword, UserDetails userDetails)
        {
            try
            {
                UsersDao.FindByUserName(userName);

                throw new DuplicateInstanceException(userName,
                    typeof(Users).FullName);
            }
            catch (InstanceNotFoundException)
            {
                String encryptedPassword = PasswordEncrypter.Crypt(clearPassword);

                Users usuario = new Users();

                usuario.userName = userName;
                usuario.password = encryptedPassword;

                usuario.firstName = userDetails.firstName;
                usuario.lastName = userDetails.lastName;
                usuario.email = userDetails.Email;
                usuario.idiom = userDetails.idiom;
                usuario.country = userDetails.country;
                usuario.admin = false;

                UsersDao.Create(usuario);

                return usuario.usrId;
            }
        }

        public UserDetails FindUserDetails(long usrId)
        {
            Users userFind = UsersDao.Find(usrId);
            UserDetails userDetails = new UserDetails (userFind.userName, userFind.firstName, userFind.lastName, userFind.email, userFind.idiom, userFind.country);
            return userDetails;
        }

        public void UpdateUserProfileDetails(long usrId, UserDetails userDetails)
        {
            Users user = UsersDao.Find(usrId);

            user.userName = userDetails.userName;
            user.firstName = userDetails.firstName;
            user.lastName = userDetails.lastName;
            user.email = userDetails.Email;
            user.idiom = userDetails.idiom;
            user.country = userDetails.country;
            user.admin = user.admin;

            UsersDao.Update(user);
        }


        public void ChangePassword(long usrId, string oldps, string newps)
        {
            Users user = UsersDao.Find(usrId);

            String storedPassword = user.password;

            if (!PasswordEncrypter.IsClearPasswordCorrect(oldps,
                 storedPassword))
            {
                throw new IncorrectPasswordException(user.userName);
            }

            user.password = PasswordEncrypter.Crypt(newps);

            UsersDao.Update(user);
        }

        public bool UserExists(string userName)
        {
            try
            {
                Users usuario = UsersDao.FindByUserName(userName);
            }
            catch (InstanceNotFoundException e)
            {
                return false;
            }
            return true;
        }

        public bool IsUserAdmin(long usrId)
        {
            Users user = UsersDao.Find(usrId);
            return (bool)user.admin;
        }
    }
}
