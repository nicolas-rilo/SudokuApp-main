using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.SudokuApp.Model.ParticipantDao
{
    public interface IParticipantDao : IGenericDao<Participant, Int64>
    {
        void participate(Users user, Tournament tournament, TimeSpan time);

    }
}
