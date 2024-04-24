using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.SudokuApp.Model;

namespace Es.Udc.DotNet.SudokuApp.ModelUsersDao
{
    public class UserDaoEntityFramework : GenericDaoEntityFramework<Users, Int64>, IUsersDao
    {
        public UserDaoEntityFramework()
        {
        }


        public Users FindByUserName(string userName)
        {
            Users user = null;

            DbSet<Users> users = Context.Set<Users>();

            var result =
                (from u in users
                 where u.userName == userName
                 select u);

            user = result.FirstOrDefault();

            if (user == null)
                throw new InstanceNotFoundException(userName,
                    typeof(Users).FullName);

            return user;
        }

    }
}
