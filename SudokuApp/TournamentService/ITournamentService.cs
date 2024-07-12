using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.SudokuApp.Model.TournamentDao;
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Model.TournamentService
{
    public interface ITournamentService
    {
        [Inject]
        ITournamentDao tournamentDao { set; }

        long createTournament(long sudokuId, DateTime start, DateTime end);

        void participateInTournament(long usrId, long tournamentId, TimeSpan time);

        TournamentDto getTournament(long tournamentId);

        List<TournamentDto> getActiveTournaments();

        ParticipationDto getUserRank(long usrId, long tournamentId);

        List<ParticipationDto> getRanking(long tournamentId, int start, int size);
    }
}
