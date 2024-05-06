using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.SudokuApp.Model.KillerDao
{
    public class KillerBoxDaoEntityFramework : GenericDaoEntityFramework<Killer_box, Int64>, IKillerBoxDao
    {
        public KillerBoxDaoEntityFramework()
        {
        }
    }
}
