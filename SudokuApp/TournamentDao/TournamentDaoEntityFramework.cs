using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.SudokuApp.Model.TournamentDao
{
    public class TournamentDaoEntityFramework : GenericDaoEntityFramework<Tournament, Int64>, ITournamentDao
    {
        public long createTournament(Sudoku sudoku, DateTime init, DateTime end)
        {
            Tournament tournament = new Tournament();
            tournament.sudokuId = sudoku.sudokuId;
            tournament.start_time = init;
            tournament.finish_time = end;

            base.Create(tournament);
            return tournament.tournamentId;
        }

        public List<Tournament> getActiveTournaments()
        {
            DbSet<Tournament> tournaments = Context.Set<Tournament>();
            var result =
                (from i in tournaments
                 where i.finish_time > DateTime.Now
                 orderby i.finish_time 
                 select i
                 );
            return result.ToList();
        }

        public ParticipationDto getRank(Users user, Tournament tournament)
        {
            DbSet<Participant> participants = Context.Set<Participant>();
            List<ParticipationDto> participationDtos = new List<ParticipationDto>();

            var result =
                (from i in participants
                 where i.tournamentId == tournament.tournamentId
                 orderby i.time ascending
                 select new
                 {
                     Time = i.time,
                     UserName = i.Users.userName,
                     userId = i.userId,
                     Rank = (from o in participants
                             where o.time < i.time
                             select o).Count() + 1
                 });

            foreach (var a in result) {
                ParticipationDto participationDto = new ParticipationDto(a.Time,a.UserName,a.userId,a.Rank);
                participationDtos.Add(participationDto);
            }


            try{

                return participationDtos.Where(a => a.userName == user.userName).First();

            }catch (InvalidOperationException) {

                throw new ModelUtil.Exceptions.InstanceNotFoundException(participationDtos,"participationDtos");

            }
        }

        public List<ParticipationDto> getRanking(Tournament tournament, int start, int size)
        {
            DbSet<Participant> participants = Context.Set<Participant>();
            List<ParticipationDto> participationDtos = new List<ParticipationDto>();

            var result =
                (from i in participants
                 where i.tournamentId == tournament.tournamentId
                 orderby i.time ascending
                 select new
                 {
                     Time = i.time,
                     UserName = i.Users.userName,
                     UserId = i.userId,
                     Rank = (from o in participants
                             where o.time < i.time
                             select o).Count() + 1
                 });

            foreach (var a in result)
            {
                ParticipationDto participationDto = new ParticipationDto(a.Time,a.UserName, a.UserId, a.Rank);
                participationDtos.Add(participationDto);
            }

            return participationDtos.Skip(start).Take(size).ToList();
        }

    }
}
