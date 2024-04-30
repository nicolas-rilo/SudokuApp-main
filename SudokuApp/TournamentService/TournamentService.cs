using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.SudokuApp.Model.ParticipantDao;
using Es.Udc.DotNet.SudokuApp.Model.SudokuDao;
using Es.Udc.DotNet.SudokuApp.Model.TournamentDao;
using Es.Udc.DotNet.SudokuApp.ModelUsersDao;
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Model.TournamentService
{
    public class TournamentService : ITournamentService
    {
        [Inject]
        public IUsersDao usersDao { private get; set; }
        [Inject]
        public ISudokuDao sudokuDao { private get; set; }
        [Inject]
        public ITournamentDao tournamentDao { private get; set; }
        [Inject]
        public IParticipantDao participantDao { private get; set; }

        public long createTournament(long sudokuId, DateTime start, DateTime end)
        {
            Sudoku s = sudokuDao.Find(sudokuId);
            return tournamentDao.createTournament(s,start,end);
        }

        public List<ParticipationDto> getRanking(long tournamentId, int start, int size)
        {
            return tournamentDao.getRanking(tournamentDao.Find(tournamentId), start, size);
        }

        public ParticipationDto getUserRank(long usrId, long tournamentId)
        {
            return tournamentDao.getRank(usersDao.Find(usrId),tournamentDao.Find(tournamentId));
        }

        public void participateInTournament(long usrId, long tournamentId, TimeSpan time)
        {
            participantDao.participate(usersDao.Find(usrId),tournamentDao.Find(tournamentId),time);
        }
    }
}
