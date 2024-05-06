using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.SudokuApp.Model.KillerDao;

namespace Es.Udc.DotNet.SudokuApp.Model.ArrowDao
{
    public class ArrowDaoEntityFramework : GenericDaoEntityFramework<Arrow, Int64>, IArrowDao
    {
        public ArrowDaoEntityFramework()
        {
        }
    }
}
