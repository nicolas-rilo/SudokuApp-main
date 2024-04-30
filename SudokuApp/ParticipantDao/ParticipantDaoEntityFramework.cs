using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.SudokuApp.Model.ParticipantDao
{
    public class ParticipantDaoEntityFramework : GenericDaoEntityFramework<Participant, Int64>, IParticipantDao
    {
        public void participate(Users user, Tournament tournament, TimeSpan time)
        {
            Participant participant = new Participant();
            participant.time = time;
            participant.tournamentId = tournament.tournamentId;
            participant.userId = user.usrId;
            base.Create(participant);

        }
    }
}
