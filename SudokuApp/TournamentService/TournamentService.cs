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

        public List<TournamentDto> getActiveTournaments()
        {
            List<TournamentDto> tournamentDtos = new List<TournamentDto>();
            List<Tournament> tournaments = tournamentDao.getActiveTournaments();

            foreach (Tournament i in tournaments) {
                TimeSpan time = (TimeSpan)(i.finish_time - DateTime.Now);
                

                TournamentDto tournamentDto = new TournamentDto(time.Days,time.Hours,time.Minutes,time.Seconds,i.Participant.Count
                    ,i.Sudoku.dificulty,i.Sudoku.sudokuId,i.tournamentId);
                tournamentDtos.Add(tournamentDto);
            
            }

            return tournamentDtos;
        }

        public List<ParticipationDto> getRanking(long tournamentId, int start, int size)
        {
            return tournamentDao.getRanking(tournamentDao.Find(tournamentId), start, size);
        }

        public TournamentDto getTournament(long tournamentId)
        {
            Tournament tournament = tournamentDao.Find(tournamentId);
            TimeSpan time = (TimeSpan)(tournament.finish_time - DateTime.Now);

            return new TournamentDto(time.Days, time.Hours, time.Minutes, time.Seconds, tournament.Participant.Count
                    , tournament.Sudoku.dificulty, tournament.Sudoku.sudokuId, tournament.tournamentId);
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
