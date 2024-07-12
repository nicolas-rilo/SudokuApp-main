using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.SudokuApp.Model.TournamentDao
{
    public class TournamentDto
    {
        public int days { get; private set; }
        public int hours { get; private set; }
        public int minutes { get; private set; }
        public int seconds { get; private set; }
        public int participants { get; private set; }
        public string dificulty { get; private set; }
        public long sudokuId { get; private set; }
        public long tournamentId { get; private set; }

        public TournamentDto(int days, int hours, int minutes, int seconds, int participants, string dificulty, long sudokuId, long tournamentId)
        {
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.participants = participants;
            this.dificulty = dificulty;
            this.sudokuId = sudokuId;
            this.tournamentId = tournamentId;
        }
    }
}
