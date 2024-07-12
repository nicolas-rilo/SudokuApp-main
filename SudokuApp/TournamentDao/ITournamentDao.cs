using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.SudokuApp.Model.TournamentDao
{
    public interface ITournamentDao : IGenericDao<Tournament, Int64>
    {
        long createTournament(Sudoku sudoku, DateTime init, DateTime end);

        ParticipationDto getRank(Users user, Tournament tournament);

        List<Tournament> getActiveTournaments();

        List<ParticipationDto> getRanking(Tournament tournament, int start, int size);
    }
}
