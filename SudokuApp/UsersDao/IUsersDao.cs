using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.UsersDao
{
    public interface IUsersDao: IGenericDao<Users, Int64>
    {
        /// <summary>
        /// Finds a Usuario by pseudonim
        /// </summary>
        /// <param name="pseudonim">pseudonim</param>
        /// <returns>The Usuario</returns>
        /// <exception cref="InstanceNotFoundException"/>
        Users FindByUserName(string userName);

    }
}
