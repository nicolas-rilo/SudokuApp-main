using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.SudokuApp.Model.TournamentDao
{
    public class ParticipationDto
    {
        public TimeSpan time { get; private set; }
        public long userId { get; private set; }
        public int rank { get; private set; }

        public ParticipationDto(TimeSpan time, long userId, int rank)
        {
            this.time = time;
            this.userId = userId;
            this.rank = rank;
        }
    }
}
